using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
namespace InstallerClasses
{
    [RunInstaller(true)]
    public partial class EventLog : Installer
    {
        private EventLogInstaller eventLogInstaller;
        /// <summary>
        /// Creates the event log for MyApp
        /// </summary>
        public EventLog()
        {
            InitializeComponent();
            // Create an instance of an EventLogInstaller.
            eventLogInstaller = new EventLogInstaller();
            // Set the source name of the event log.
            eventLogInstaller.Source = "MySource";
            // Set the event log that the source writes entries to.
            eventLogInstaller.Log = "Application";
            // Add myEventLogInstaller to the Installer collection.
            Installers.Add(eventLogInstaller);
        }
    }
}
