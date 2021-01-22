using System;
using System.Web;
using UBTS.Entities;
using System.Data.SqlClient;
public class FileHandler : IHttpAsyncHandler
{
    #region Variables
    private HttpContext _currentContext = null;
    protected SqlCommand _command = null;
    protected delegate void DoNothingDelegate();
    #endregion
    public void ProcessRequest(HttpContext context)
    {
    }
    public void DoNothing()
    {
    }
    public bool IsReusable
    {
        get { return false; }
    }
    #region IHttpAsyncHandler Members
    public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
    {
        
        _currentContext = context;
        
        int imageId;
        if (int.TryParse(context.Request.QueryString["imageId"], out imageId))
        {
            // begin get file - change to yourself
            // return FileController.BeginGetFile(out _command, cb, extraData, imageId);
        }
        else
        {
            DoNothingDelegate doNothingDelegate = new DoNothingDelegate(DoNothing);
            
            return doNothingDelegate.BeginInvoke(cb, extraData);
        }
    }
    public void EndProcessRequest(IAsyncResult result)
    {
        File file = null;
        if (null != _command)
        {
            try
            {   
                // end get file - change to yourself
                // file = FileController.EndGetFile(_command, result);
            }
            catch { }
        }
        if (null != file)
        {
            if (null == file.Data)
            {
                _currentContext.Response.Redirect(file.Path);
            }
            else
            {
                _currentContext.Response.ContentType = file.ContentType;
                _currentContext.Response.BinaryWrite(file.Data);
                _currentContext.Response.AddHeader("content-disposition", "filename=\"" + file.Name + (file.Name.Contains(file.Extension) ? string.Empty : file.Extension) + "\"" );
                _currentContext.Response.AddHeader("content-length", (file.Data == null ? "0" : file.Data.Length.ToString()));
                
            }
			_currentContext.Response.Cache.SetCacheability(HttpCacheability.Private);
			_currentContext.Response.Cache.SetExpires(DateTime.Now);
			_currentContext.Response.Cache.SetSlidingExpiration(false);
			_currentContext.Response.Cache.SetValidUntilExpires(false);
						_currentContext.Response.Flush();
        }
        else
        {
            throw new HttpException(404, HttpContext.GetGlobalResourceObject("Image", "NotFound") as string);
        }
    }
    #endregion
}
