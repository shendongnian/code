    <%@ Page Language="C#"%>
    <%@ Import Namespace="System.Collections.Generic" %>
    <%@ Import Namespace="System.Linq" %>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <script runat="server">
        public class Person   // replace with your class
        {
            public string person_name {get; set;}
        }
        public class Repository  // replace with your class
        {
            public static IEnumerable<Record> GetCustomerByDateCategory()
            {
                // fake some data
                return new Record[] 
                {
                    new Record { Time = new DateTime(2000, 1, 1, 8, 0, 0), Contractor = new Person {person_name = "Joe the Plumber"},  Customer = new Person {person_name = "Joe Smith"} },
                    new Record { Time = new DateTime(2000, 1, 1, 8, 30, 0), Contractor = new Person {person_name = "Bob Vila"}, Customer = new Person {person_name = "Frank Johnson"} },
                    new Record { Time = new DateTime(2000, 1, 1, 8, 30, 0), Contractor = new Person {person_name = "Mr. Clean"}, Customer = new Person  {person_name = "Elliott P. Ness"} },
                };
            }
            public class Record    // replace this class with your record's class
            {
                public DateTime Time {get; set;}
                public Person Contractor { get; set; }
                public Person Customer { get; set; }
            }
        }
        
        // key = time, value = ordered (by contractor) list of customers in that time slot
        public class CustomersByTime : SortedDictionary<DateTime, List<Person>>
        {
            public List<Person> Contractors { get; set; }
            
            public CustomersByTime (IEnumerable <Repository.Record> records)
            {
                Contractors = new List<Person>();
                foreach (Repository.Record record in records)
                {
                    int contractorIndex = Contractors.FindIndex(p => p.person_name == record.Contractor.person_name);
                    if (contractorIndex == -1)
                    {
                        Contractors.Add(record.Contractor);
                        contractorIndex = Contractors.Count - 1;
                    }
                    List<Person> customerList;
                    if (!this.TryGetValue(record.Time, out customerList))
                    {
                        customerList = new List<Person>();
                        this.Add(record.Time, customerList);
                    }
                    while (customerList.Count < contractorIndex)
                        customerList.Add (null);    // fill in blanks if needed
                    customerList.Add (record.Customer);    // fill in blanks if needed
                }
                MakeSameLength();
            }
            // extend each list to match the longest one. makes databinding easier.
            public void MakeSameLength()
            {
                int max = 0;
                foreach (var value in this.Values)
                {
                    if (value.Count > max)
                        max = value.Count;
                }
                foreach (var value in this.Values)
                {
                    while (value.Count < max)
                        value.Add(null);
                }
            }
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomersByTime Customers = new CustomersByTime(Repository.GetCustomerByDateCategory());
            CustomerListView.DataSource = Customers;
            CustomerListView.DataBind();
        }
    </script> 
    <html>
    <head>
    <style type="text/css">
        td, th, table { border:solid 1px black; border-collapse:collapse;}
    </style>
    </head>
    <body>
      <asp:Repeater ID="CustomerListView" runat="server">
        <HeaderTemplate><table cellpadding="2" cellspacing="2"></HeaderTemplate>
        <ItemTemplate>
            <asp:Repeater runat="server" visible="<%#Container.ItemIndex==0 %>"
                DataSource="<%#((CustomersByTime)(CustomerListView.DataSource)).Contractors %>" >
              <HeaderTemplate>
                <tr>
                   <th>Times</th>
               </HeaderTemplate>
              <ItemTemplate>
                <th><%#((Person)Container.DataItem).person_name %></th>
              </ItemTemplate>
              <FooterTemplate>            
                </tr>
              </FooterTemplate>
            </asp:Repeater>
          <tr>
            <td><%#((KeyValuePair<DateTime, List<Person>>)(Container.DataItem)).Key.ToShortTimeString() %></td>
            <asp:Repeater ID="Repeater1" runat="server" DataSource="<%# ((KeyValuePair<DateTime, List<Person>>)(Container.DataItem)).Value %>">
              <ItemTemplate>
                <td align="left" style="width: 200px;">
                  <%#Container.DataItem == null ? "" : ((Person)(Container.DataItem)).person_name%>
                </td> 
              </ItemTemplate>
            </asp:Repeater>
          </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
      </asp:Repeater>
    </body>
    </html>
