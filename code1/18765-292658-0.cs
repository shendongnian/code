    public void itemRemoved(final ModelEvent me)
    {
       final TableViewer tableViewer = this.viewer;
    
       if (tableViewer != null)
       {
          display.asyncExec(new Runnable()
          {
             public void run()
             {
                tableViewer.remove(me.getItem());
             }
          }
       }
    }
