    namespace Application.Models.ApplicationViewModels
    {
        public class StoreIndexData
        {
            [Display(Name = "Departamento")]
            public int DepartmentId { get; set; }
            public string DepartmentName { get; set; }    
    
            [Display(Name = "Distrito")]    
            public int DistrictId { get; set; }
            public string DistrictName { get; set; }
            [EnumDataType(typeof(TiendaCadenaEnum))]
            public TiendaCadenaEnum TiendaCadena { get; set; }
        }
    
        public enum TiendaCadenaEnum
            {
            [Display(Name = "Cencosud")]
            Cencosud,
            [Display(Name = "Cinerama")]
            Cinerama,
        }
    }
    
    @model Application.Models.ApplicationviewModels.StoreIndexData
    @using Application.Models.ApplicationviewModels
    @using Application.Models
    
        <div class="form-group">
            <label asp-for="TiendaCadena" class="cold-md-2"></label>
            <div class="col-md-10">
                <select asp-for="TiendaCadena" class="form-control"
                        asp-items="Html.GetEnumSelectList<TiendaCadenaEnum>()">"></select>
                <span asp-validation-for="TiendaCadena" class="text-danger"></span>
            </div>
        </div>
