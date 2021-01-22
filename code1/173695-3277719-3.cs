      void grid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e) {
         //save my data source
         var nameArray = this.MyPersonDataSource.Select(item => item.Name).ToArray();
         //create the csv string
         String csvString = String.Join("," nameArray);
         //write it to a file
         System.IO.File.WriteAllText(@"C:\SomeFolderYouHavePermissionsOn\names.csv", csvString);
      }
