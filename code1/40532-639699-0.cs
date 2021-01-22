        // ...
        m_scale = value; 
        if ( !this.DesignMode && StartImageProcThread( ) )
        {
            OnIntensityscaleChanged( EventArgs.Empty );
        }  
        // ...
        private bool StartImageProcThread( )
        {                        
            if ( !worker.IsBusy )
            {                     
                worker.RunWorkerAsync( );
                return true;
            }
            return false;
        }
