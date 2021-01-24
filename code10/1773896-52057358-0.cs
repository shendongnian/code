    //... Some other code
    while (sd.Read()) {
      inputName.Text = sd.GetValue(1).ToString();
      inputClass.Text = sd.GetValue(2).ToString();
    }
    
    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    sb.Append(@"<script type='text/javascript'>");
    sb.Append("$('#exampleModalCenter').modal('show');");
    sb.Append(@"</script>");
    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyModel", 
    sb.ToString(), false);
