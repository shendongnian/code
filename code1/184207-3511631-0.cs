            // Create test data table with messageid as primary column
            DataTable dt = new DataTable();
            dt.Columns.Add("MessageID", typeof (int));
            dt.Columns.Add("SenderID", typeof(int));
            dt.Columns.Add("MessageContent", typeof(string));
            dt.PrimaryKey = new[] {dt.Columns["MessageID"]};
            // Add some data
            dt.Rows.Add(1, 10, "Message1");
            dt.Rows.Add(2, 11, "Message2");
            dt.Rows.Add(3, 12, "Message3");
            dt.Rows.Add(4, 13, "Message4");
            // Create second test data table with single row
            DataTable dtMsg = new DataTable();
            dtMsg.Columns.Add("MessageID", typeof(int));
            dtMsg.Columns.Add("SenderID", typeof(int));
            dtMsg.Columns.Add("MessageContent", typeof(string));
            dtMsg.PrimaryKey = new[] { dtMsg.Columns["MessageID"] };
            dtMsg.Rows.Add(3, 12, "Message3");
            // Not very elegant way of getting the message id from dtMsg. 
            int messageId = (int)dtMsg.Rows[0][0];
            int index = dt.Rows.IndexOf(dt.Rows.Find(messageId));
            
            // Result : index is 2
            Console.WriteLine(index);
