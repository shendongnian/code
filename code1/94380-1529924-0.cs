    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    
    namespace SearchingList
    {
        public partial class Form1 : Form
        {
            private int searchingID = 0;
            public int SearchingID 
            {
                get
                {       
                    if (string.IsNullOrEmpty(txtID.Text))
                        searchingID = 0;
                    else
                        int.TryParse(txtID.Text, out searchingID);
                    return searchingID;
                }
                set
                {
                    SearchingID = searchingID;
                }
            }
            public Form1()
            {
                InitializeComponent();
            }
    
            private void btnsearch_Click(object sender, EventArgs e)
            {
                List<Customer> lstcustomersFound = new List<Customer>();
                Stopwatch stp = new Stopwatch();
                stp.Start();
                lstcustomersFound = GetSearchedCustomersByLinq(SearchingID, (List<Customer>)dgvAllData.DataSource);
                stp.Stop();
                lblLinq.Text = "Elapsed Time Linq : " + stp.ElapsedMilliseconds.ToString() + " ms";
                stp.Start();
                lstcustomersFound = GetSearchedCustomersByForLoop(SearchingID, (List<Customer>)dgvAllData.DataSource);
                stp.Stop();
                lblFor.Text ="Elapsed Time for loop : " + stp.ElapsedMilliseconds.ToString() + " ms";
                dgvSearched.DataSource = lstcustomersFound;
            }
    
            private List<Customer> GetSearchedCustomersByForLoop(int searchingID, List<Customer> lstcustomers)
            {
                List<Customer> lstcustomersFound = new List<Customer>();
                foreach (Customer customer in lstcustomers)
                {
                    if (customer.CusomerID.ToString().Contains(searchingID.ToString()))
                    {
                        lstcustomersFound.Add(customer);
                    }
                }
                return lstcustomersFound;
            }
    
            private List<Customer> GetSearchedCustomersByLinq(int searchingID, List<Customer> lstcustomers)
            {
                var query = from customer in lstcustomers
                            where customer.CusomerID.ToString().Contains(searchingID.ToString())
                            select customer as Customer;
                return query.ToList();
            }
    
    
            private void Form1_Load(object sender, EventArgs e)
            {
                List<Customer> customers = new List<Customer>();
                Customer customer;
                for (int id = 1; id <= 50000; id++)
                {
                    customer = new Customer();
                    customer.CusomerAddress = "Address " + id.ToString();
                    customer.CusomerID = id;
                    customer.CusomerName = "Cusomer Name " + id.ToString(); 
                    customer.CusomerPhone= "Phone " + id.ToString();
                    customers.Add(customer);
                }
                dgvAllData.DataSource = customers;
            }
    
        }
    }
