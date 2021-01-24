    Model
    
    public class GenerateModel
    {
        public string Id { get; set; }
        public int MonsterLevelId { get; set; }
        public int NbMosnterId { get; set; }
        public IEnumerable<SelectListItem> MonsterLevel { get; set; }
        public IEnumerable<SelectListItem> NbMonster { get; set; }
        public string result { get; set; }
    }
    
    Controller
   
        public ActionResult Index() 
        
                {
                    var model = new GenerateModel
                    {
                        NbMonster = new[]{
                     new SelectListItem { Text = "1", Value = "1" },
                     new SelectListItem { Text = "2", Value = "2" }
                        },
                        MonsterLevel = new[]{
                    new SelectListItem { Text = "2", Value = "2" }
                        }
                    };
        
                    return View(model);
                }
        
                [HttpPost]
                public ActionResult Generate(GenerateModel model)
                {
                    ModelState.Clear();
                    model.result = (model.MonsterLevelId + model.NbMosnterId).ToString();
                    model.NbMonster = new[]{
                     new SelectListItem { Text = "1", Value = "1" },
                     new SelectListItem { Text = "2", Value = "2" }
                        };
                    model.MonsterLevel = new[]{
                    new SelectListItem { Text = "2", Value = "2" }
                        };
        
                    return View("Index", model);
                }
    
    View
    
       
    
         @model WebApplication1.Models.GenerateModel
            
            
            @using (Html.BeginForm("Generate", "Home", FormMethod.Post))
            {
            <dl class="row">
                <dt>
                    @Html.DisplayNameFor(model => model.NbMonster)
                    @Html.DropDownListFor(x => x.NbMosnterId, new SelectList(Model.NbMonster, "Value", "Text"))
                </dt>
                <dt>
                    @Html.DisplayNameFor(model => model.MonsterLevel)
                    @Html.DropDownListFor(x => x.MonsterLevelId, new SelectList(Model.MonsterLevel, "Value", "Text"))
                </dt>
                @Html.TextAreaFor(m => m.result)
                
            </dl>
            <input type="submit" value="generate" class="btn" />
            }  
