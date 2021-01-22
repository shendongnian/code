       public void Do(int id)
       {
           // call the WCF-Service
            DataContainer.instance.dataSource.GetConsumtionInfoAsync(id);
       }
