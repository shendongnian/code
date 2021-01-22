    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading;
    
    class PersistenceManager
    {
       public void Persist(ICollection persistable)
       {
          // initialize a list of background workers
          var backgroundWorkers = new List<BackgroundWorker>();
    
          // launch each persistable item in a background worker on a separate thread
          foreach (var persistableItem in persistable)
          {
             var worker = new BackgroundWorker();
             worker.DoWork += new DoWorkEventHandler(worker_DoWork);
             backgroundWorkers.Add(worker);
             worker.RunWorkerAsync(persistableItem);
          }
    
          // wait for all the workers to finish
          while (true)
          {
             // sleep a little bit to give the workers a chance to finish
             Thread.Sleep(100);
    
             // continue looping until all workers are done processing
             if (backgroundWorkers.Exists(w => w.IsBusy)) continue;
    
             break;
          }
    
          // dispose all the workers
          foreach (var w in backgroundWorkers) w.Dispose();
       }
    
       void worker_DoWork(object sender, DoWorkEventArgs e)
       {
          var persistableItem = e.Argument;
          // TODO: add logic here to save the persistableItem to the database
       }
    }
