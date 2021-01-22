    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Management;
    namespace DeviceMonitor.Event
    {
        /// <summary>Media watcher delegate.</summary>
        /// <param name="sender"></param>
        /// <param name="driveStatus"></param>
        public delegate void MediaWatcherEventHandler(object sender, DeviceMonitor.Event.MediaEvent.DriveStatus driveStatus );
    
        /// <summary>Class to monitor devices.</summary>
        public class MediaEvent
        {
            #region Variables
            /*------------------------------------------------------------------------*/
            private string m_logicalDrive;
            private ManagementEventWatcher m_managementEventWatcher = null;
            /*------------------------------------------------------------------------*/
            #endregion
            #region Events
            /*------------------------------------------------------------------------*/
            public event MediaWatcherEventHandler MediaWatcher;
            /*------------------------------------------------------------------------*/
            #endregion
            #region Enums
            /*------------------------------------------------------------------------*/
            /// <summary>The drive types.</summary>
            public enum DriveType
            {
              Unknown = 0,
              NoRootDirectory = 1,
              RemoveableDisk  = 2,
              LocalDisk       = 3,
              NetworkDrive    = 4,
              CompactDisk     = 5,
              RamDisk         = 6
            }
            /// <summary>The drive status.</summary>
            public enum DriveStatus
            {
              Unknown  = -1,
              Ejected  = 0,
              Inserted = 1,
            }
           
           /*-----------------------------------------------------------------------*/
           #endregion
           #region Monitoring
           /*-----------------------------------------------------------------------*/
           /// <summary>Starts the monitoring of device.</summary>
           /// <param name="path"></param>
           /// <param name="mediaEvent"></param>
           public void Monitor( string path, MediaEvent mediaEvent ) 
           {
               if( null == mediaEvent ) 
               {
                  throw new ArgumentException( "Media event cannot be null!" );
               }
               //In case same class was called make sure only one instance is running
               /////////////////////////////////////////////////////////////
               this.Exit();
               //Keep logica drive to check
               /////////////////////////////////////////////////////////////
               this.m_logicalDrive = this.GetLogicalDrive( path );
               WqlEventQuery wql;
               ManagementOperationObserver observer = new ManagementOperationObserver();
               //Bind to local machine
               /////////////////////////////////////////////////////////////
               ConnectionOptions opt = new ConnectionOptions();
   
               //Sets required privilege
               /////////////////////////////////////////////////////////////
               opt.EnablePrivileges = true;
               ManagementScope scope = new ManagementScope( "root\\CIMV2", opt );
               try 
               {
                  wql = new WqlEventQuery();
                  wql.EventClassName = "__InstanceModificationEvent";
                  wql.WithinInterval = new TimeSpan( 0, 0, 1 );
                  wql.Condition = String.Format( @"TargetInstance ISA 'Win32_LogicalDisk' and TargetInstance.DeviceId = '{0}'", this.m_logicalDrive );
                  this.m_managementEventWatcher = new ManagementEventWatcher( scope, wql );
                  //Register async. event handler
                  /////////////////////////////////////////////////////////////
                  this.m_managementEventWatcher.EventArrived += new EventArrivedEventHandler( mediaEvent.MediaEventArrived );
                  this.m_managementEventWatcher.Start();
               } 
               catch( Exception e ) 
               {
                  this.Exit();
                  throw new Exception( "Media Check: "  + e.Message );
               }
           }
           /// <summary>Stops the monitoring of device.</summary>
           public void Exit( ) 
           {
                 //In case same class was called make sure only one instance is running
                 /////////////////////////////////////////////////////////////
                 if( null != this.m_managementEventWatcher ) 
                 {
                      try 
                      {
                           this.m_managementEventWatcher.Stop();
                           this.m_managementEventWatcher = null;
                      } 
                      catch {}
                 }
            }
            /*-----------------------------------------------------------------------*/
            #endregion
  
  
            #region Helpers
            /*-----------------------------------------------------------------------*/
            private DriveStatus m_driveStatus = DriveStatus.Unknown;
            /// <summary>Triggers the event when change on device occured.</summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void MediaEventArrived( object sender, EventArrivedEventArgs e ) 
            {
   
                // Get the Event object and display it
                PropertyData pd = e.NewEvent.Properties["TargetInstance"];
                DriveStatus driveStatus = this.m_driveStatus;
   
                if( pd != null ) 
                {
                    ManagementBaseObject mbo = pd.Value as ManagementBaseObject;
                    System.IO.DriveInfo info = new System.IO.DriveInfo( (string)mbo.Properties["DeviceID"].Value );
                    driveStatus = info.IsReady ? DriveStatus.Inserted : DriveStatus.Ejected;
                }
   
                if( driveStatus != this.m_driveStatus )
                {
                    this.m_driveStatus = driveStatus;
                    if( null != MediaWatcher ) 
                    {
                        MediaWatcher( sender, driveStatus );
                    }
                }
            }
  
  
            /// <summary>Gets the logical drive of a given path.</summary>
            /// <param name="path"></param>
            /// <returns></returns>
            private string GetLogicalDrive( string path ) 
            {
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo( path );
                string root = dirInfo.Root.FullName;
                string logicalDrive = root.Remove(root.IndexOf(System.IO.Path.DirectorySeparatorChar ) );
                return logicalDrive;
            }
            /*-----------------------------------------------------------------------*/
            #endregion
        }
    }
