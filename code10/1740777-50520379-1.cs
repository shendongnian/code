        //Form 1
		public string status; 						// create global string to be accessed in form2
		Form2 fm2 = new Form2();          			// make an instance of form 2
		fm2.stored_status = status;					// assign the stored value to the getter and setter in form 2
		fm2.ShowDialog();                 			// open form2 in dialog style            
		status = fm2.GetStatus(fm2.checkBox1);  	//call the function and store
		// Form 2
		public string stored_status { get; set; } // define getter and setter 
		private void Form2_Load(object sender, EventArgs e) // use in form load
		{
		    if (stored_status == "checked") 		// check if stored value equal checked
		        checkBox1.Checked = true; 			// make the checkbox checked
		    else									// if not 
		        checkBox1.Checked = false;		    // keep it unchecked
		}
		public string GetStatus(CheckBox check) // returns string  and takes paramter of checkbox
		{
		    if (check.Checked == true)       	 // check if checkbox1 is checked
		        return "checked";            	// return value checked
		    else                            	 // if not 
		        return "unchecked";         	// return value unchecked
		}
