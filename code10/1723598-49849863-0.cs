    Model.db_ExamOnlineEntities dbobj = new Model.db_ExamOnlineEntities();
    
    private void Form1_Load(object sender, EventArgs e)
    {
        Model.Table_Question qs = new Model.Table_Question();
    
        var query = dbobj.Table_Question.Find(qs.qtext).Take(20);
    
        for (int i = 0; i < 20; i++)
        {
            label1.Text = query.ToString();
        }
    }
