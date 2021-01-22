     protected void btnOK_Click(object sender, EventArgs e)
            {
               
              // Your code goes here.
              if(isSuccess)
              {
                      string  close =    @"<script type='text/javascript'>
				                    window.returnValue = true;
				                    window.close();
				                    </script>");
				base.Response.Write(close);
                }
                
            }
