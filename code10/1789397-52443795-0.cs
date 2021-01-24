    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click( object sender, EventArgs e )
            {
                List<DataTransferObject> dtos = new List<DataTransferObject>();
                dtos.Add( new DataTransferObject() { Field = FieldId.FieldA, Text = textBox1.Text } );
                dtos.Add( new DataTransferObject() { Field = FieldId.FieldB, Text = textBox2.Text } );
    
                BusinessThing businessThing = new BusinessThing();
                businessThing.Validate( dtos );
    
                foreach( var dto in dtos )
                {
                    if( dto.Error != null )
                    {
                        if( dto.Field == FieldId.FieldA )
                        {
                            label1.Text = dto.Error;
                        }
                        // etc
                    }
                }
            }
        }
    
        public enum FieldId
        {
            FieldA,
            FieldB
        }
    
        public class DataTransferObject
        {
            public FieldId Field { get; set; }
            public String Text { get; set; }
            public String Error { get; set; } = null;
        }
    
        public class BusinessThing
        {
            private Regex regex = new Regex(@"^((\d+\.?\d*),{1}(\d+\.?\d*))$");
    
            public void Validate( List<DataTransferObject> dtos )
            {
                foreach( var dto in dtos )
                {
                    Validate( dto );
                }
            }
    
            public void Validate( DataTransferObject dto )
            {
                if( ValidateCoordonate( dto ) )
                {
                    ValidateRange( dto );
                }
            }
    
            public Boolean ValidateCoordonate( DataTransferObject dto )
            {
                Match match = regex.Match(dto.Text);
    
                if( match.Success )
                {
                    return true;
                }
                else
                {
                    dto.Error = "Invalid coordinates!";
                    return false;
                }
            }
    
    
            public Boolean ValidateRange( DataTransferObject dto )
            {
                float x = float.Parse(dto.Text.Split(',')[0]);
                float y = float.Parse(dto.Text.Split(',')[1]);
    
                if( (x < 10 || x > 1000) || (y < 10 || y > 730) )
                {
                    dto.Error = "Invalid range!";
                    return false;
                }
                return true;
            }
        }
    }
