    private void Form1_Load(object sender, EventArgs e)
                {
                    this.comboBoxSubjectCName.DataSource = this.Student.TableClass;
                    this.comboBoxSubjectCName.DisplayMember = TableColumn.ClassName;//Column name that will be the DisplayMember
                    this.comboBoxSubjectCName.ValueMember = TableColumn.ClassID;//Column name that will be the ValueMember
                }
