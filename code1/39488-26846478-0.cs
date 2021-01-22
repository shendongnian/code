     //c#
     //In parent page
     public void test(string S)
     {
	    Label1.Text = S;
      }
     //In user control
     protected void Button1_Click(object sender, System.EventArgs e)
     {
	 //Calling "test method" of parent page  from user control  
	 ((object)this.Page).test("Hello!!");
     }
     'VB.Net 
    'In parent page
     Sub test(ByVal S As String)
        Label1.Text = S
     End Sub
     'In user control
      Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
      'Calling "test method" of parent page  from user control  
      DirectCast(Me.Page, Object).test("Hello!!")
      End Sub 
