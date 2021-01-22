    private readonly bool useDBServer;
    public Form2(DataGridView dgv, bool useDBServer, bool useOther)
    {
       this.useDBServer = useDBServer; // Copy parameter to instance variable
       if(useDBServer) 
       {
         //stuff
       }
    }
    private void readRegistry()
    {
       if(useDBServer) // Use the instance variable
       {
         //stuff
       }
    }
