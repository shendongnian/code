    private void SaveCommand()
    {
    	string strJsonResult = JsonConvert.SerializeObject(
    		new {
    			SelectedScalesModel = this.SelectedScalesModel,
    			SelectedScalesPort = this.SelectedScalesPort
    		}
    	);
    	File.WriteAllText("setup.json", strJsonResult);
    	MessageBox.Show("File save in Json Format");
    }
