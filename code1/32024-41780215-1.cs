    public class MyApiController: Controller
    {
        [HttpGet]
        public IActionResult Get(int? myEnumParam){    
            MyEnumType myEnumParamParsed;
            if(!EnumUtils.TryParse<MyEnumType>(myEnumParam, out myEnumParamParsed)){
                return BadRequest($"Error: parameter '{nameof(myEnumParam)}' is not specified or incorrect");
            }      
           
            return this.Get(washingServiceTypeParsed);            
        }
        private IActionResult Get(MyEnumType myEnumParam){ 
           // here we can guarantee that myEnumParam is valid
        }
