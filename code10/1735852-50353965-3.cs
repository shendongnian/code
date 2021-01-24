    public class MessageController : Controller
        [HttpPost]
        public ActionResult SendMessage(ChatModel viewModel)
        {
    var message = viewModel.Message;
    // Code to save to file here
