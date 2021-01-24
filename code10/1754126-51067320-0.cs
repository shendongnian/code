    [WebMethod]
    public bool insertRecord(List<People> stu)
    {
        using (LearnershipDBEntities dn = new LearnershipDBEntities())
        {
            Person obj = new Person();
            foreach (var item in stu)
            {
                obj.personID = item.personId;
                obj.dateOfBirth = item.dob;
                obj.idNumber = item.idNumber;
                obj.name = item.name;
                obj.title = item.title;
                dn.People.Add(obj);
            }
            
            dn.SaveChanges();
        }
        return true;
    }
    private void button2_Click(object sender, EventArgs e)
    {
        try
        {
            ToDbXml.Service2 nb = new ToDbXml.Service2();
            Service2Client s = new Service2Client();
            List<People> listOfPeople = new List<People>();
            
            for (int i = 0; i <= 4; i++)
            {    
                listOfPeople.add (
                new People() 
                {
               
                name = string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[0].Value.ToString()) ? string.Empty : dataGridView1.Rows[i].Cells[0].Value.ToString(),
                dob = string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[1].Value.ToString()) ? (DateTime)System.Data.SqlTypes.SqlDateTime.Null : DateTime.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()),
                title = string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[2].Value.ToString()) ? string.Empty : dataGridView1.Rows[i].Cells[2].Value.ToString(),
                idNumber = string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[3].Value.ToString()) ? string.Empty : dataGridView1.Rows[i].Cells[3].Value.ToString()
              });
                          
            }
            s.insertRecord(listOfPeople); 
            MessageBox.Show("Values Inserted Succesfully");
        }
        catch (SqlException ex)
        {
            MessageBox.Show( ex.Message);
        }
    }
