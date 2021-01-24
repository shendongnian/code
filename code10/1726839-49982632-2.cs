    using System;
    using System.Collections.Generic;
    
    namespace WebApplication4GridAddRow
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            [Serializable]
            public class SampleClass
            {
                public string PropertyA { get; set; }
                public string PropertyB { get; set; }
            }
    
            //I will create this in a Session List, to mantain the state.
            //You could use Viewstate (ugly!) too, this is why SamplesClass is Serializable.
            List<SampleClass> persistedList
            {
                get
                {
                    return (List<SampleClass>)Session["samplesClass"];
                    //return (List<SampleClass>)ViewState["samplesClass"];
                }
                set
                {
                    Session.Add("samplesClass", value);
                    //ViewState.Add("samplesClass", value);
                }
            }
    
            List<SampleClass> notPersistedList = new List<SampleClass>();
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    persistedList = new List<SampleClass> {
                        new SampleClass { PropertyA = "smth", PropertyB = "something" },
                        new SampleClass { PropertyA = "smthA", PropertyB = "somethingA" }
                    };
    
                    GridView1.DataSource = persistedList;
                    GridView1.DataBind();
    
                    notPersistedList = new List<SampleClass> {
                        new SampleClass { PropertyA = "smth", PropertyB = "something" },
                        new SampleClass { PropertyA = "smthA", PropertyB = "somethingA" }
                    };
    
                    GridView2.DataSource = notPersistedList;
                    GridView2.DataBind();
                }
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                persistedList.Add(new SampleClass { PropertyA = "smth" + persistedList.Count, PropertyB = "something" + persistedList.Count });
    
                GridView1.DataSource = persistedList;
                GridView1.DataBind();
            }
            
            protected void Button2_Click(object sender, EventArgs e)
            {
                notPersistedList.Add(new SampleClass { PropertyA = "smth" + notPersistedList.Count, PropertyB = "something" + notPersistedList.Count });
    
                GridView2.DataSource = notPersistedList;
                GridView2.DataBind();
            }
        }
    }
