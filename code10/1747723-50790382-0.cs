            private void addPhotoBtn_Click(object sender, RoutedEventArgs e)
             {
                 openfile = new OpenFileDialog();
                 openfile.Filter = "Images |*.JPG; *.PNG";
                 if (openfile.ShowDialog() == true)
                   {
                      userImage.Source = new BitmapImage(new Uri(openfile.FileName, UriKind.RelativeOrAbsolute));
                      filename = openfile.SafeFileName;
                      sourcePath = @openfile.FileName;
                      this.FileName = @openfile.FileName;
                      targetPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "/Images/users/" + getTime + System.IO.Path.GetExtension(openfile.FileName);
                    }
               }
             private void saveUserBtn_Click(object sender, RoutedEventArgs e)
             {
               string fname, lname, username, password, email, phone, address, role, photo = "";
               int spec_id; int dept_id;
               fname = firstNameTextBox.Text.ToString();
               lname = lastNameTextBox.Text.ToString(); ;
               username = usernameTextBox.Text.ToString(); ;
               password = passwordBox.Password;
               email = emailTextBox.Text.ToString(); ;
               phone = phoneTextBox.Text.ToString(); ;
               address = addressTextBox.Text.ToString();
               spec_id = specComboBox.SelectedIndex;
               role = roleComboBox.Text.ToString();
               if (deptComboBox.SelectedIndex >= 0)
                   dept_id = int.Parse(deptComboBox.SelectedValue.ToString());
               else
                    dept_id = 0;
                 // Input Validation
              if (state == "add" && sourcePath != null || sourcePath != null && state != "add")
               {
                  photo = new Uri("pack://application:,,/CMMS;component/images/users/") + getTime + System.IO.Path.GetExtension(this.FileName);
                }
            .
            .
            .
