    public class Category{
         public int CategoryId { get; private set; }
         public string CategoryName { get; private set; }
         public int ParentId { get; private set; }
         public List<Category> ChildCategories { get; private set; }
         
         //I would recommend using a parentId of 0 or some other int value that can't occur in your database to describe a category that has no parent.
         public Category(int categoryId, string categoryName, int parentId)
         {
             CategoryId = categoryId;
             CategoryName = categoryName;
             ParentId = parentId;
             ChildCategories = getChildCategories();
         }
         
         //I didn't have this method setting the ChildCategories directly because I would 
         //recommend refactoring your data access code into a data access class of some sort
         //also depending on the amount of categories you could be generating a lot of database calls.
         //It may make more sense to get the whole table and pass in the resulting dataset, then use recursion to build your nested category structure.
         private List<Category> getChildCategories()
         {
              List<Category> resultingCategories = new List<Category>();
              //Data access logic here to get a dataset assume the variable holding the  
              //data reader is named sdr
              while (sdr.Read()){
                  //This assumes categoryId is the first column
                  int childCategoryId = Convert.ToInt32(sdr[0]);
                  
                  //This assumes categoryName is the second column
                  string childCategoryName = sdr[1];
                  
                  Category childCategory = new Category(childCategoryId, childCategoryName, CategoryId);
                  resultingCategories.Add(childCategory);
              }
              return resultingCategories;
         }
    }
