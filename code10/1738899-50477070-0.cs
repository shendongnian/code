    public class Column
    {
        public bool IsGeneratedAlwaysType;
---------  
        private void SetupConfig()
        {
	        else if (IsGeneratedAlwaysType)
            {
                if(Settings.UseDataAnnotations)
                    DataAnnotations.Add("DatabaseGenerated(DatabaseGeneratedOption.Computed)");
                else
                    databaseGeneratedOption = string.Format(".HasDatabaseGeneratedOption({0}DatabaseGeneratedOption.Computed)", schemaReference);
            }
