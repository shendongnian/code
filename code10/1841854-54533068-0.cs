	private void InvokeIfRequired<C>(C control, Action<C> action) where C : Control
	{
		if (control.InvokeRequired)
		{
			control.Invoke((Action)(() => action(control)));
		}
		else
		{
			action(control);
		}
	}
	
	private void backup_button_Click(object sender, EventArgs e)
	{
		var principalForm = System.Windows.Forms.Application.OpenForms.OfType<Form1>().FirstOrDefault();
		if (principalForm.drive_selector.SelectedItem != null)
		{
			principalForm.backup_button.Visible = false;
			
			string temp = principalForm.drive_selector.SelectedItem.ToString();
		
			TextBox test = principalForm.textBox2;
			ProgressBar progress_bar = principalForm.progressBar1;
	
			Action<string> updateTest = t => this.InvokeIfRequired<TextBox>(test, c => c.Text = t);
			Action<int> updateProgress = v => this.InvokeIfRequired<ProgressBar>(progress_bar, c => c.Value = v);
	
			Thread backupprocess = new Thread(new ThreadStart(() => sales_backup.backup_start(temp, updateTest, updateProgress)));
			backupprocess.Start();
		}
	}
	
	//Backup Function
	public void backup_start(string temp, Action<string> updateTest, Action<int> updateProgress)
	{
		files_to_copy = 0;
		files_copied = 0;
	
		//Set Parameters
		
		error_copy = false;
		error_message = "";
		device_removed = false;
	
		//Fill variables
		temp = regex_matching_return_match(temp, @"[A-Z,a-z](:\\)");
		backup_device = temp;
	
		//Set Backup device size
		for (int i = 0; i < backup_devices_list.Count; i++)
		{
			if (backup_devices_list[i].backup_device_name == temp)
			{
				backup_device_size = backup_devices_list[i].device_size;
				file_system = backup_devices_list[i].file_system;
				double temp_free = calculate_GB(backup_devices_list[i].device_free_space.ToString());
				device_free_space = temp_free;
				break;
			}
		}
	
		//If no device is initialized
		if (backup_device == null || backup_device_size == 0)
		{
			write_to_textbox(get_create_usb_instance_error(), "red");
		}
		else //If select ist successfull
		{
			//Get Backup size
			get_size();
			if (backup_size < device_free_space)
			{
				backup_path_target = backup_device + "\\Backup\\";
				Directory.CreateDirectory(backup_path_target);
	
				//Get file count
				get_file_count();
	
				//Create Copy job
				for (int i = 0; i < backup_path_source.Length; i++)
				{
					string backup_path_s = backup_path_source[i] + "\\";
					string backup_path_t = backup_path_target + backup_path_target_folders[i] + "\\";
					copy_function(backup_path_s, backup_path_t);
					int progress = return_progress();
	
					//Delegate Textbox
					updateTest("Copying: " + backup_path_t);
	
					//Delegate Progressbar
					updateProgress(progress);
				}
			}
		}
	}
