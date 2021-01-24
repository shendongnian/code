    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;
    
    namespace InsertUpdateDelete {
        public partial class Form1 : Form {
            public class PersonState {
                public string Name { get; set; }
                public string State { get; set; }
            }
            public List<PersonState> listOfPersonState;
            public Form1() {
                InitializeComponent();
                listOfPersonState = new List<PersonState>();
            }
            //Display Data in DataGridView  
            private void DisplayData() {
                DataTable dt = new DataTable();
                dt = ConvertToDatatable();
                dataGridView1.DataSource = dt;
            }
            //Clear Data  
            private void ClearData() {
                txt_Name.Text = "";
                txt_State.Text = "";
            }
            public DataTable ConvertToDatatable() {
                DataTable dt = new DataTable();
                dt.Columns.Add("Name");
                dt.Columns.Add("State");
                foreach (var item in listOfPersonState) {
                    var row = dt.NewRow();
                    row["Name"] = item.Name;
                    row["State"] = item.State;
                    dt.Rows.Add(row);
                }
                return dt;
            }
            private void AddToList(string text1, string text2) {
                listOfPersonState.Add(new PersonState { Name = text1, State = text2 });
            }
            private void UpdateToList(string text1, string text2) {
                int index = dataGridView1.SelectedRows[0].Index;
                listOfPersonState[index] = new PersonState { Name = text1, State = text2 };
            }
            private void DeleteToList() {
                int index = dataGridView1.SelectedRows[0].Index;
                listOfPersonState.RemoveAt(index);
            }
            private void btn_Insert_Click(object sender, EventArgs e) {
                if (txt_Name.Text != "" && txt_State.Text != "") {
                    AddToList(txt_Name.Text, txt_State.Text);
                    //MessageBox.Show("Record Inserted Successfully");
                    DisplayData();
                    ClearData();
                } else {
                    MessageBox.Show("Please Provide Details!");
                }
            }
            private void btn_Update_Click(object sender, EventArgs e) {
                if (txt_Name.Text != "" && txt_State.Text != "") {
                    if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0) {
                        UpdateToList(txt_Name.Text, txt_State.Text);
                        //MessageBox.Show("Record Updated Successfully");
                        DisplayData();
                        ClearData();
                    }    
                } else {
                    MessageBox.Show("Please Select Record to Update");
                }
            }
            private void btn_Delete_Click(object sender, EventArgs e) {
                if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0) {
                    DeleteToList();
                    //MessageBox.Show("Record Deleted Successfully!");
                    DisplayData();
                    ClearData();
                } else {
                    MessageBox.Show("Please Select Record to Delete");
                }
            }
    
            private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
                FillInputControls(e.RowIndex);
            }
            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
                FillInputControls(e.RowIndex);
            }
            private void FillInputControls(int Index) {
                if (Index > -1) {
                    txt_Name.Text = dataGridView1.Rows[Index].Cells[0].Value.ToString();
                    txt_State.Text = dataGridView1.Rows[Index].Cells[1].Value.ToString();
                }
            }
        }
    }
