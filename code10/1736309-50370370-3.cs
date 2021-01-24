    public class  ControllerBase: Controller {
        //Matches obtenerAngulos/y/x
        [HttpGet]
        [Route("~/obtenerAngulos/{Conex_AT}/{Conex_BT}")]
        public JsonResult obtenerAngulos(string Conex_AT, string Conex_BT) {
            //...
        }
    }
