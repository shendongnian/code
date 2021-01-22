    public class CategoryFinder:I1, I2
    {
         public DataTable GetSubCategoriesBySubCatID(Guid SubCategoryID) //Implicitly implementing interface 
         {   
              //processing
              return _dt; 
         }
         List<SubCategories> I2.GetSubCategoriesBySubCatID(Guid SubCategoryID) //explicit implementing interface
         {
               //processing
               return _list<>
         }
    }
