    using Microsoft.AspNetCore.Http;
    
    var result = new ObjectResult("Your message");
    result.StatusCode = StatusCodes.Status418ImATeapot;
    return result;
