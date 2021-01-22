public ActionResult EmployeeImage(int id)
{
    byte[] imageData ="Retrieve your Byte[] data from database";
    if (imageData!= null && imageData.Length > 0)
    {
        return new FileStreamResult(new System.IO.MemoryStream(imageData), "image/jpeg");
    }
}
