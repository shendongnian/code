    void MainFormLoad(object sender, EventArgs e)
		{
				//Each of the following lists populate the ComboBoxes to be selected on the main form. 
				//Amperage List, No Exclusions-----------------------------------------------------------
				List<string> amperage = new List<string>();
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
				
				//Cable List, No Exclusions --------------------------------------------------------------
				List<string> cable_size1 = new List<string>();
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
				//Initial DataBind for cable size ComboBox
				
				//System Type List	
				List<string> system_type_list = new List<string>();
				system_type_list.Add("Select System Type");
				system_type_list.Add("3 Phase 3 Wire");
				system_type_list.Add("3 Phase 4 Wire");
			
				cb_test_3.DataSource = system_type_list;
				cb_test_3.SelectedIndex = 0;
				//Initial DataBind for cb_system type ComboBox				
		}
		
		
		double x, y, z;
		
		void Button1Click(object sender, System.EventArgs e)
		{
			//-----------------------------Dictionaries-----------------------------------------------
			//Amperage Dictionary	
			Dictionary<string, double> amperage_dictionary = new Dictionary<string, double>();
		
			amperage_dictionary.Add ("400", 400);
			amperage_dictionary.Add ("800", 800);
			amperage_dictionary.Add ("1000", 1000);
			amperage_dictionary.Add ("1200", 1200);
			amperage_dictionary.Add ("1600", 1600);
			amperage_dictionary.Add ("2000", 2000);
			amperage_dictionary.Add ("2500", 2500);
			amperage_dictionary.Add ("3000", 3000);
			amperage_dictionary.Add ("3200", 3200);
			amperage_dictionary.Add ("4000", 4000);
			amperage_dictionary.Add ("5000", 5000);
			amperage_dictionary.Add ("6000", 6000);			
					
			//Cable Dictionary 1 used for cable quantity calculation
			Dictionary<string, double> cable_dictionary_1 = new Dictionary<string, double>();
			
			cable_dictionary_1.Add ("#1", 130);
			cable_dictionary_1.Add ("1/0", 150);
			cable_dictionary_1.Add ("2/0", 175);
			cable_dictionary_1.Add ("3/0", 200);
			cable_dictionary_1.Add ("4/0", 230);
			cable_dictionary_1.Add ("250", 255);
			cable_dictionary_1.Add ("300", 285);
			cable_dictionary_1.Add ("400", 355);
			cable_dictionary_1.Add ("500", 380);
			cable_dictionary_1.Add ("600", 720);
			cable_dictionary_1.Add ("750", 475);
			
			//System Type Dictionary
			Dictionary<string, double> system_type = new Dictionary<string, double>();
			system_type.Add("Select System Type", 0);
			system_type.Add("3 Phase 3 Wire", 3);
			system_type.Add("3 Phase 4 Wire", 4);
			
					
			if (!String.IsNullOrEmpty(cb_test_1.Text) && (!String.IsNullOrEmpty(cb_test_2.Text) && (!String.IsNullOrEmpty(cb_test_3.Text))))
				{	
					double a;
					if (cb_test_1.SelectedText == ("400"))
						{
							x = amperage_dictionary["400"];					
						}		
					
					if (cb_test_1.SelectedText == ("800"))
						{
							x = amperage_dictionary["800"];					
						}	
					
					if (cb_test_2.SelectedText == ("#1"))
						{
							y = amperage_dictionary["#1"];					
						}	
				
					if (cb_test_2.SelectedText == ("1/0"))
						{
							y = amperage_dictionary["1/0"];					
						}	
								
					if (cb_test_3.SelectedText == ("3 Phase 3 Wire"))
						{
							z = system_type["3 Phase 3 Wire"];					
						}
					if (cb_test_3.SelectedText == ("3 Phase 4 Wire"))
						{
							z = system_type["3 Phase 4 Wire"];
						}
								
					a = ((x / y)*z);
					this.tb_1.Text = Math.Round(a,2).ToString();
						
				}
			
					
		}
	
			
		
	}
