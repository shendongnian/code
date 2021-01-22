    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsApplication1
    {
    	public class Form1 : Form
    	{
    		private List<HelloWorld> helloWorlds;
    
    		#region Form1.Designer.cs
    		/// <summary>
    		/// Required designer variable.
    		/// </summary>
    		private System.ComponentModel.IContainer components = null;
    
    		/// <summary>
    		/// Clean up any resources being used.
    		/// </summary>
    		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    		protected override void Dispose( bool disposing )
    		{
    			if ( disposing && (components != null) )
    			{
    				components.Dispose();
    			}
    			base.Dispose( disposing );
    		}
    
    		#region Windows Form Designer generated code
    
    		/// <summary>
    		/// Required method for Designer support - do not modify
    		/// the contents of this method with the code editor.
    		/// </summary>
    		private void InitializeComponent()
    		{
    			this.comboBox1 = new RefreshingComboBox();
    			this.comboBox2 = new RefreshingComboBox();
    			this.label1 = new System.Windows.Forms.Label();
    			this.label2 = new System.Windows.Forms.Label();
    			this.button1 = new System.Windows.Forms.Button();
    			this.button2 = new System.Windows.Forms.Button();
    			this.button3 = new System.Windows.Forms.Button();
    			this.SuspendLayout();
    			// 
    			// comboBox1
    			// 
    			this.comboBox1.FormattingEnabled = true;
    			this.comboBox1.Location = new System.Drawing.Point( 76, 12 );
    			this.comboBox1.Name = "comboBox1";
    			this.comboBox1.Size = new System.Drawing.Size( 115, 21 );
    			this.comboBox1.TabIndex = 0;
    			// 
    			// comboBox2
    			// 
    			this.comboBox2.FormattingEnabled = true;
    			this.comboBox2.Location = new System.Drawing.Point( 250, 12 );
    			this.comboBox2.Name = "comboBox2";
    			this.comboBox2.Size = new System.Drawing.Size( 218, 21 );
    			this.comboBox2.TabIndex = 1;
    			// 
    			// label1
    			// 
    			this.label1.AutoSize = true;
    			this.label1.Location = new System.Drawing.Point( 12, 15 );
    			this.label1.Name = "label1";
    			this.label1.Size = new System.Drawing.Size( 58, 13 );
    			this.label1.TabIndex = 2;
    			this.label1.Text = "Language:";
    			// 
    			// label2
    			// 
    			this.label2.AutoSize = true;
    			this.label2.Location = new System.Drawing.Point( 213, 15 );
    			this.label2.Name = "label2";
    			this.label2.Size = new System.Drawing.Size( 31, 13 );
    			this.label2.TabIndex = 3;
    			this.label2.Text = "Text:";
    			// 
    			// button1
    			// 
    			this.button1.Location = new System.Drawing.Point( 34, 42 );
    			this.button1.Name = "button1";
    			this.button1.Size = new System.Drawing.Size( 75, 23 );
    			this.button1.TabIndex = 4;
    			this.button1.Text = "Set All";
    			this.button1.UseVisualStyleBackColor = true;
    			this.button1.Click += new System.EventHandler( this.button1_Click );
    			// 
    			// button2
    			// 
    			this.button2.Location = new System.Drawing.Point( 116, 42 );
    			this.button2.Name = "button2";
    			this.button2.Size = new System.Drawing.Size( 75, 23 );
    			this.button2.TabIndex = 5;
    			this.button2.Text = "Set Random";
    			this.button2.UseVisualStyleBackColor = true;
    			this.button2.Click += new System.EventHandler( this.button2_Click );
    			// 
    			// button3
    			// 
    			this.button3.Location = new System.Drawing.Point( 393, 42 );
    			this.button3.Name = "button3";
    			this.button3.Size = new System.Drawing.Size( 75, 23 );
    			this.button3.TabIndex = 6;
    			this.button3.Text = "Refresh!";
    			this.button3.UseVisualStyleBackColor = true;
    			this.button3.Click += new System.EventHandler( this.button3_Click );
    			// 
    			// Form1
    			// 
    			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
    			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    			this.ClientSize = new System.Drawing.Size( 556, 77 );
    			this.Controls.Add( this.button3 );
    			this.Controls.Add( this.button2 );
    			this.Controls.Add( this.button1 );
    			this.Controls.Add( this.label2 );
    			this.Controls.Add( this.label1 );
    			this.Controls.Add( this.comboBox2 );
    			this.Controls.Add( this.comboBox1 );
    			this.Name = "Form1";
    			this.Text = "Form1";
    			this.ResumeLayout( false );
    			this.PerformLayout();
    
    		}
    
    		#endregion
    
    		private System.Windows.Forms.ComboBox comboBox1;
    		private System.Windows.Forms.ComboBox comboBox2;
    		private System.Windows.Forms.Label label1;
    		private System.Windows.Forms.Label label2;
    		private System.Windows.Forms.Button button1;
    		private System.Windows.Forms.Button button2;
    		private System.Windows.Forms.Button button3;
    
    		#endregion
    
    		public Form1()
    		{
    			InitializeComponent();
    
    			comboBox1.DataSource = new HelloWorld().GetLanguages();
    
    			helloWorlds = new List<HelloWorld>();
    			while ( helloWorlds.Count < 10 )
    			{
    				helloWorlds.Add( new HelloWorld() );
    			}
    
    			comboBox2.DataSource = helloWorlds;
    		}
    
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault( false );
    			Application.Run( new Form1() );
    		}
    
    		private void changeAllLanguages()
    		{
    			HelloWorld.LanguageValue newLang = (HelloWorld.LanguageValue) comboBox1.SelectedValue;
    
    			helloWorlds.ForEach(
    				delegate( HelloWorld hw )
    				{
    					hw.Language = newLang;
    				} );
    
    		}
    
    		private void changeRandomLanguage()
    		{
    			int index = new Random().Next( helloWorlds.Count );
    			HelloWorld.LanguageValue newLang = (HelloWorld.LanguageValue) comboBox1.SelectedValue;
    
    			helloWorlds[index].Language = newLang;
    		}
    
    		private void button1_Click( object sender, EventArgs e )
    		{
    			changeAllLanguages();
    		}
    
    		private void button2_Click( object sender, EventArgs e )
    		{
    			changeRandomLanguage();
    		}
    
    		private void button3_Click( object sender, EventArgs e )
    		{
    			(comboBox2 as RefreshingComboBox).RefreshItems();
    		}
    	}
    
    	public class RefreshingComboBox : System.Windows.Forms.ComboBox
    	{
    		public new void RefreshItem(int index)
    		{
    			base.RefreshItem(index);
    		}
    
    		public new void RefreshItems()
    		{
    			base.RefreshItems();
    		}
    	}
    
    	public class HelloWorld
    	{
    		public enum LanguageValue
    		{
    			English,
    			日本語,
    			Deutsch,
    			Français,
    			Český
    		}
    
    		private LanguageValue language;
    
    		public LanguageValue Language
    		{
    			get
    			{
    				return language;
    			}
    			set
    			{
    				language = value;
    			}
    		}
    
    		public Array GetLanguages()
    		{
    			return Enum.GetValues( typeof( LanguageValue ) );
    		}
    
    		Dictionary<LanguageValue, string> helloWorlds;
    
    		public HelloWorld()
    		{
    			helloWorlds = new Dictionary<LanguageValue, string>();
    			helloWorlds[LanguageValue.English] = "Hello, world!";
    			helloWorlds[LanguageValue.日本語] = "こんにちは、世界！";
    			helloWorlds[LanguageValue.Deutsch] = "Hallo, Welt!";
    			helloWorlds[LanguageValue.Français] = "Sallut, monde!";
    			helloWorlds[LanguageValue.Český] = "Ahoj svět!";
    		}
    
    		public override string ToString()
    		{
    			return helloWorlds[language];
    		}
    	}
    }
