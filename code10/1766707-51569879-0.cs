    protected void btnsubmit_Click(object sender, EventArgs e)
    {
    int val = 0;
    if (textarea.Text != "")
    {    
    string SUCode = textarea.Text;
    SUCode = SUCode.Replace("\"","").Replace("[","").Replace("]","");
          
    string[] myarray = SUCode.Split(',');
    SUCode = "";
    for (var i = 0; i < myarray.Length; i++)
    {
            SUCode += myarray[i];
            if(i < myarray.Length-1)
                SUCode += ",";
    }
    }
    }
