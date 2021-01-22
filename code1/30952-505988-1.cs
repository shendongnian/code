    partial class MainForm
	{
		double x, y, z;		
		
		List<string> cable_size1;
		List<string> system_type_list;
		List<string> amperage;
		
		Dictionary<string, double> cable_dictionary_1;
		Dictionary<string, double> system_type;
		Dictionary<string, double> amperage_dictionary;
    private void MainFormLoad(object sender, EventArgs e)
		{
				//Each of the following lists populate the ComboBoxes
				//to be selected on the main form.
				amperage = new List<string>();
				cable_size1 = new List<string>();
				system_type_list = new List<string>();			
				
				cable_dictionary_1 = new Dictionary<string, double>();
				system_type = new Dictionary<string, double>();
				amperage_dictionary = new Dictionary<string, double>();
				
				//
				InitializeCurrentLoadCB();
				InitializeCableSizeCB();
				InitializeSystemTypeCB();
				
				//---------------Dictionaries---------------------------------------------------------
				InitializeSystemTypeLookup();
				InitializeCableLookup();
				InitializeAmperageLookup();
		}
		private void InitializeCurrentLoadCB()
		{
				//Amperage List, No Exclusions-----------------------------------------------------------
				amperage = new List<string>();
				amperage.Add("Please Select Amperage");
				amperage.Add("400");
				amperage.Add("800");
				amperage.Add("1000");
				amperage.Add("1200");
				amperage.Add("1600");
				amperage.Add("2000");
				amperage.Add("2500");
				amperage.Add("3000");
				amperage.Add("3200");
				amperage.Add("4000");
				amperage.Add("5000");
				amperage.Add("6000");
			
				cb_test_1.DataSource = amperage;
				cb_test_1.SelectedIndex = 0;
				cb_test_1.DropDownStyle = ComboBoxStyle.DropDownList;
		}
		private void InitializeCableSizeCB()
		{
				//Cable List, No Exclusions --------------------------------------------------------------
				cable_size1 = new List<string>();
				cable_size1.Add("Please Select Cable Size");
				cable_size1.Add ("#1");
				cable_size1.Add ("1/0");
				cable_size1.Add ("2/0");
				cable_size1.Add ("3/0");
				cable_size1.Add ("4/0");
				cable_size1.Add ("250");
				cable_size1.Add ("300");
				cable_size1.Add ("400");
				cable_size1.Add ("500");
				cable_size1.Add ("600");
				cable_size1.Add ("700");
				cable_size1.Add ("750");
			
				cb_test_2.DataSource = cable_size1;
				cb_test_2.SelectedIndex = 0;
				cb_test_2.DropDownStyle = ComboBoxStyle.DropDownList;
				//Initial DataBind for cable size ComboBox
		}
		private void InitializeSystemTypeCB()
		{
				//System Type List	
				system_type_list = new List<string>();
				system_type_list.Add("Select System Type");
				system_type_list.Add("3 Phase 3 Wire");
				system_type_list.Add("3 Phase 4 Wire");
			
				cb_test_3.DataSource = system_type_list;
				cb_test_3.SelectedIndex = 0;
				cb_test_3.DropDownStyle = ComboBoxStyle.DropDownList;
				//Initial DataBind for cb_system type ComboBox				
		}
		
		
		private void Button1Click(object sender, System.EventArgs e)
		{	
			
			if (!String.IsNullOrEmpty(cb_test_1.Text) &&
			   (!String.IsNullOrEmpty(cb_test_2.Text) && 
			   (!String.IsNullOrEmpty(cb_test_3.Text))))
				{	
					double a;
					if (cb_test_1.SelectedIndex != 0)
						{
							x = amperage_dictionary[amperage[cb_test_1.SelectedIndex]];					
						}														
				
					if (cb_test_2.SelectedIndex != 0)
						{
							y = cable_dictionary_1[cable_size1[cb_test_2.SelectedIndex]];					
						}	
								
					if (cb_test_3.SelectedIndex != 0)
						{
							z = system_type[system_type_list[cb_test_3.SelectedIndex]];
						}			
								
					a = ((x / y)*z);
					this.tb_1.Text = Math.Round(a,2).ToString();
						
				}
							
		}
		private void InitializeSystemTypeLookup()
		{
			//System Type Dictionary
			this.system_type = new Dictionary<string, double>();
			this.system_type.Add(this.system_type_list[0], 0);
			this.system_type.Add(this.system_type_list[1], 3);
			this.system_type.Add(this.system_type_list[2], 4);
		}
		private void InitializeCableLookup()
		{
			//Cable Dictionary 1 used for cable quantity calculation
			this.cable_dictionary_1 = new Dictionary<string, double>();
			this.cable_dictionary_1.Add (this.cable_size1[0], 0);
			this.cable_dictionary_1.Add (this.cable_size1[1], 130);
			this.cable_dictionary_1.Add (this.cable_size1[2], 150);
			this.cable_dictionary_1.Add (this.cable_size1[3], 175);
			this.cable_dictionary_1.Add (this.cable_size1[4], 200);
			this.cable_dictionary_1.Add (this.cable_size1[5], 230);
			this.cable_dictionary_1.Add (this.cable_size1[6], 255);
			this.cable_dictionary_1.Add (this.cable_size1[7], 285);
			this.cable_dictionary_1.Add (this.cable_size1[8], 355);
			this.cable_dictionary_1.Add (this.cable_size1[9], 380);
			this.cable_dictionary_1.Add (this.cable_size1[10], 720);
			this.cable_dictionary_1.Add (this.cable_size1[11], 475);
		}
		private void InitializeAmperageLookup()
		{
			//Amperage Dictionary	
			this.amperage_dictionary = new Dictionary<string, double>();
			this.amperage_dictionary.Add(this.amperage[0], 0);
			this.amperage_dictionary.Add(this.amperage[1], 400);
			this.amperage_dictionary.Add(this.amperage[2], 800);
			this.amperage_dictionary.Add(this.amperage[3], 1000);
			this.amperage_dictionary.Add(this.amperage[4], 1200);
			this.amperage_dictionary.Add(this.amperage[5], 1600);
			this.amperage_dictionary.Add(this.amperage[6], 2000);
			this.amperage_dictionary.Add(this.amperage[7], 2500);
			this.amperage_dictionary.Add(this.amperage[8], 3000);
			this.amperage_dictionary.Add(this.amperage[9], 3200);
			this.amperage_dictionary.Add(this.amperage[10], 4000);
			this.amperage_dictionary.Add(this.amperage[11], 5000);
			this.amperage_dictionary.Add(this.amperage[12], 6000);		
		}
		
		
	}
		
    
