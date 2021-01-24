    [Route("api/StÃ¤dte")] // UTF-8 "ä" (0xc3a4) → ISO-8859-1 "Ã¤".
    [Route("API/STÃ„DTE")] // UTF-8 "Ä" (0xc384) → ISO-8859-1 "Ã„".
    [Route("api/[controller]")] // Default.
    [ApiController]
    public class StädteController : ControllerBase
    {
        //...
    }
