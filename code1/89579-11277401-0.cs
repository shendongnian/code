    public dragdropentity TestLB; //dragdropentity is my actuall control containing my ListBox
    
            [CommandMethod("ListBox")]
            public void lb()
            {
                if (this.TestLB == null)
                {
                    myPaletteSet = new PaletteSet("Test ListBox", new Guid("{B32639EE-05DF-4C48-ABC4-553769C67995}"));
                    TestLB = new dragdropentity();
                    myPaletteSet.Add("LB", TestLB);
    
                }
                myPaletteSet.Visible = true;
            }
 
