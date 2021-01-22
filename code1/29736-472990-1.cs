    public class WordResult : ActionResult
    {
    public string FileName { get { return "Resume.doc"; } }
    public override void ExecuteResult(ControllerContext context)
    {
      GenerateMsWordDoc(context);
    }
    public void GenerateMsWordDoc(ControllerContext context)
    {
      // You can add whatever you want to add as the HTML and it will be generated as Ms Word docs
      context.HttpContext.Response.AppendHeader("Content-Type", "application/msword");
      context.HttpContext.Response.AppendHeader("Content-disposition", "attachment; filename=" + FileName);
    }
