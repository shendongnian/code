    public class Company
    {
        public IList<Person> Employees { get; set; } = new List<Person>();
    }
    public class Person
    {
        public FormFileWrapper IdImage { get; set; }
    }
    public class FormFileWrapper
    {
        public IFormFile File { get; set; }
    }
then you don have to add the index in your html
<form action="http://localhost:5000/api/Values" method="post" enctype="multipart/form-data">
    <p><input type="file" name="Employees[0].IdImage.File"></p>
    <p><input type="file" name="Employees[1].IdImage.File"></p>
    <p><button type="submit">Submit</button></p>
</form>
  [1]: https://github.com/aspnet/AspNetCore/issues/4802#issuecomment-456117442
