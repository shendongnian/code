        /// <summary>
        /// Setter priorité
        /// NoECO juste quand check? 
        /// </summary>
        /// <param name="ID"></param>
        private static void Insert_Demande_Willy_DTL(int ID)
        {
            {
                DemoInfo_IndusEntities context = new DemoInfo_IndusEntities();
                context.CreateDessinDTL.Add(new CreateDessinDTL_Demo()
                {
                    ConfigName = "",
                    C_ID = ID,
                    NoECO = Willy.Properties.Settings.Default.EcoName,
                    Priority = 2,
                    Statut = AppConfig.Controller.Statuts.Willy.Willy2,
                    TestedBy = Environment.UserName
                    //CreatePDF = Willy.Properties.Settings.Default.GeneratePDF.ToString(),
                });
                context.SaveChanges();
            }}
