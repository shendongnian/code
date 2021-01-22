    try
    {
    System.Drawing.Image imgg1 = System.Drawing.Image.FromFile(Server.MapPath("").ToString() + "\\images\\img1.jpg");
     }
     catch (FileNotFoundException)
    {
     Response.Write("<script>alert('Please Select and upload Student's Photo');</script>");
      }
    catch(Exception ex)
    {
       Response.Write("Ex: " + ex.GetType().ToString());
    }
