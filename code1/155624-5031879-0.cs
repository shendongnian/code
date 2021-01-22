    using System;  
    using System.Collections.Generic;  
    using System.ComponentModel;  
    using System.Data;  
    using System.Drawing;  
    using System.Linq;  
    using System.Text;  
    using System.Windows.Forms;  
    using System.Data.SqlClient;  
    using Microsoft.Win32;  
    using System.Runtime.InteropServices;   
    
    
    namespace CopyDatabase 
    {  
     public partial class Synchronize : Form 
     {      
       [DllImport("ODBCCP32.dll")]  
       private static extern bool SQLConfigDataSource(IntPtr parent, int request, string
       driver, string attributes);    
    
       public Synchronize()     
       {         
         InitializeComponent();     
       }      
           
       private void button1_Click(object sender, EventArgs e)     
       {        
         string str  = "SERVER=HOME\0DSN=MYDSN\0DESCRIPTION=MYDSNDESC\0DATABASE=DBServer\0TRUSTED_CONNECTION=YES";         
    SQLConfigDataSource((IntPtr)0, 4, "SQL Server",str);     
       } 
      } 
