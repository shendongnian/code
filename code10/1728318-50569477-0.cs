    public CallResult<String> PostJournal()
    {
        //calling start of sage session
        Session session;
        int a = -1;
        //database link for sage
        DBLink mDBLinkCmpRW;
        ViewFields viewDetails;
        CallResult<String> result = new CallResult<String>();
        try
        {            
            session = new Session();
            //Initialisation of Sage to get the version
            session.Init("", "XY", "XY1000", GetSageVersion());
            //accessing of database with sage credentials
            session.Open("ADMIN", "ADMIN", GHOH, DateTime.UtcNow, 0);
            //start of code for inserting 
            try
            {
                mDBLinkCmpRW = session.OpenDBLink(DBLinkType.System, DBLinkFlags.ReadWrite);
                a = 2;
                // tables to be posted to are found below
                View GLBATCH1batch = mDBLinkCmpRW.OpenView("GL0008");
                var GLBATCH1batchFields = GLBATCH1batch.Fields;
                View GLBATCH1header = mDBLinkCmpRW.OpenView("GL0006");
                var GLBATCH1headerFields = GLBATCH1header.Fields;
                View GLBATCH1detail1 = mDBLinkCmpRW.OpenView("GL0010");
                var GLBATCH1detail1Fields = GLBATCH1detail1.Fields;
                View GLBATCH1detail2 = mDBLinkCmpRW.OpenView("GL0402");
                GLBATCH1batch.Compose(new View[] { GLBATCH1batch });
                GLBATCH1header.Compose(new View[] { GLBATCH1batch, GLBATCH1detail1 });
                GLBATCH1detail1.Compose(new View[] { GLBATCH1detail2 });
                GLBATCH1detail2.Compose(new View[] { GLBATCH1detail1 });
                var GLBATCH1detail2Fields = GLBATCH1detail2.Fields;
                View GLPOST2 = mDBLinkCmpRW.OpenView("GL0030");
                var GLPOST2Fields = GLPOST2.Fields;
                GLBATCH1batch.Browse("(BATCHSTAT = \"1\" OR BATCHSTAT = \"6\" OR BATCHSTAT = \"9\")", true);
                GLBATCH1batch.RecordCreate(ViewRecordCreate.Insert);
                GLBATCH1batch.Read(true);
                GLBATCH1batchFields.FieldByName("PROCESSCMD").SetValue("1", true);
                ////  Lock Batch Switch
                GLBATCH1batch.Process();
                GLBATCH1headerFields.FieldByName("BTCHENTRY").SetValue("", false);
                ////  Entry Number
                GLBATCH1header.Browse("", true);
                //"";
                //1;
                GLBATCH1header.Fetch(true);
                GLBATCH1headerFields.FieldByName("BTCHENTRY").SetValue("00000", true);
                GLBATCH1header.RecordCreate(ViewRecordCreate.DelayKey);
                //2;
                var temp = GLBATCH1header.Exists;
                GLBATCH1batchFields.FieldByName("BTCHDESC").SetValue("Testing Journal", true);
                ////  Description
                GLBATCH1batch.Update();
                var temp1 = GLBATCH1detail1.Exists;
                GLBATCH1detail1.RecordClear();
                var temp2 = GLBATCH1detail1.Exists;
                GLBATCH1detail1.RecordCreate(ViewRecordCreate.NoInsert);
                //0;
                GLBATCH1detail1Fields.FieldByName("ACCTID").SetValue("230000", true);
                GLBATCH1detail1Fields.FieldByName("TRANSDESC").SetValue("testing journal", true);
                ////  Description
                GLBATCH1detail1.Process();
                GLBATCH1detail1Fields.FieldByName("SCURNAMT").SetValue("2000.000", true);
                GLBATCH1detail1.Insert();
                GLBATCH1detail1Fields.FieldByName("TRANSNBR").SetValue("-000000001", true);
                ////  Transaction Number
                GLBATCH1detail1.Read(true);
                var temp3 = GLBATCH1detail1.Exists;
                GLBATCH1detail1.RecordCreate(ViewRecordCreate.NoInsert);
                //0;
                GLBATCH1detail1Fields.FieldByName("ACCTID").SetValue("260035", true);
                GLBATCH1detail1Fields.FieldByName("TRANSDESC").SetValue("testing journal", true);
                ////  Description
                GLBATCH1detail1.Process();
                GLBATCH1detail1Fields.FieldByName("SCURNAMT").SetValue("-2000.000", true);
                GLBATCH1detail1.Insert();
                GLBATCH1detail1Fields.FieldByName("TRANSNBR").SetValue("-000000002", true);
                ////  Transaction Number
                GLBATCH1detail1.Read(true);
                GLBATCH1batch.Read(true);
                var temp4 = GLBATCH1header.Exists;
                GLBATCH1headerFields.FieldByName("JRNLDESC").SetValue("testing journal", true);
                ////  Description
                GLBATCH1header.Insert();
                GLBATCH1header.Read(true);
                var temp5 = GLBATCH1header.Exists;
                GLBATCH1batch.Read(true);
                GLBATCH1headerFields.FieldByName("BTCHENTRY").SetValue("00000", true);
                GLBATCH1header.RecordCreate(ViewRecordCreate.DelayKey);
                //2;
                var temp6 = GLBATCH1header.Exists;
                GLBATCH1headerFields.FieldByName("BTCHENTRY").SetValue("00001", true);
                GLBATCH1header.Read(true);
                GLBATCH1batch.Read(true);
                GLBATCH1batch.Read(true);
                GLBATCH1batch.Process();
                var temp7 = GLBATCH1header.Exists;
                GLBATCH1detail1Fields.FieldByName("TRANSNBR").SetValue("0000000020", true);
                ////  Transaction Number
                GLBATCH1detail1.Read(true);
                GLBATCH1batch.Read(true);
                var temp8 = GLBATCH1header.Exists;
                GLBATCH1batchFields.FieldByName("PROCESSCMD").SetValue("2", true);
                ////  Lock Batch Switch
                GLBATCH1batch.Process();
                GLBATCH1batchFields.FieldByName("RDYTOPOST").SetValue("1", true);
                ////  Ready to Post
                GLBATCH1batch.Update();
                GLBATCH1batch.Update();
                GLBATCH1batchFields.FieldByName("PROCESSCMD").SetValue("0", true);
                ////  Lock Batch Switch
                GLBATCH1batch.Update();
                GLBATCH1batch.Process();
                GLPOST2Fields.FieldByName("BATCHIDFR").SetValue("000030", true);
                ////  From Batch Number
                GLPOST2Fields.FieldByName("BATCHIDTO").SetValue("000030", true);
                ////  To Batch Number
                GLPOST2.Process();
                GLBATCH1batch.Read(true);
                GLBATCH1batch.Read(true);
                GLBATCH1detail1Fields.FieldByName("TRANSNBR").SetValue("0000000020", true);
                ////  Transaction Number
                GLBATCH1detail1.Read(true);
                //return;
                result.Success = 1;
                result.Model = "OK";
                //end of code to insert
            }
            catch (Exception ex)
            {
                result.Success = 0;
                var errors = session.Errors;
                Console.WriteLine("Error");
                a = 16;
            }
        }
        catch (Exception ex)
        {
            result.Success = 0;
            Console.WriteLine(ex.Message);
            result.Errors = ex.Message + " " + a.ToString();
        }
        return result;
    }
