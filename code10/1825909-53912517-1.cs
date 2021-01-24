    [Produces("application/json")]
    [Route("api/Power")]
    [ApiController]
    public class PowerController : Controller
    {
        [HttpGet("Nominal/{powerFront}/{powerBack}")]
        public double NominalPower(PowerModel powerModel)
        {
            powerModel.Result = Power.NominalPower(powerModel.PowerFront, powerModel.PowerBack);
            return powerModel.Result;
        }
    }
