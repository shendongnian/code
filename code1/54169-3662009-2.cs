    public partial class WebBrowserEx : WebBrowser
        {
            AxHost.ConnectionPointCookie cookie;
            WebBrowser2EventHelper helper;
    
            [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
            protected override void CreateSink()
            {
                base.CreateSink();
    
                // Create an instance of the client that will handle the event
                // and associate it with the underlying ActiveX control.
                helper = new WebBrowser2EventHelper(this);
                cookie = new AxHost.ConnectionPointCookie(
                    this.ActiveXInstance, helper, typeof(DWebBrowserEvents2));
            }
    
            [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
            protected override void DetachSink()
            {
                // Disconnect the client that handles the event
                // from the underlying ActiveX control.
                if (cookie != null)
                {
                    cookie.Disconnect();
                    cookie = null;
                }
                base.DetachSink();
            }
    
            public event WebBrowserNavigateErrorEventHandler NavigateError;
    
            // Raises the NavigateError event.
            protected virtual void OnNavigateError(
                WebBrowserNavigateErrorEventArgs e)
            {
                if (this.NavigateError != null)
                {
                    this.NavigateError(this, e);
                }
            }
    
            // Handles the NavigateError event from the underlying ActiveX 
            // control by raising the NavigateError event defined in this class.
            private class WebBrowser2EventHelper :
                StandardOleMarshalObject, DWebBrowserEvents2
            {
                private WebBrowserEx parent;
    
                public WebBrowser2EventHelper(WebBrowserEx parent)
                {
                    this.parent = parent;
                }
    
                public void NavigateError(object pDisp, ref object url,
                    ref object frame, ref object statusCode, ref bool cancel)
                {
                    // Raise the NavigateError event.
                    this.parent.OnNavigateError(
                        new WebBrowserNavigateErrorEventArgs(
                        (String)url, (String)frame, (Int32)statusCode, cancel));
                }
            }
        }
    
        // Represents the method that will handle the WebBrowser2.NavigateError event.
        public delegate void WebBrowserNavigateErrorEventHandler(object sender,
            WebBrowserNavigateErrorEventArgs e);
    
        // Provides data for the WebBrowser2.NavigateError event.
        public class WebBrowserNavigateErrorEventArgs : EventArgs
        {
            private String urlValue;
            private String frameValue;
            private WinInetErrors statusCodeValue;
            private Boolean cancelValue;
    
            public WebBrowserNavigateErrorEventArgs(
                String url, String frame, Int32 statusCode, Boolean cancel)
            {
                urlValue = url;
                frameValue = frame;
                statusCodeValue = (WinInetErrors)statusCode;
                cancelValue = cancel;
            }
    
            public String Url
            {
                get { return urlValue; }
                set { urlValue = value; }
            }
    
            public String Frame
            {
                get { return frameValue; }
                set { frameValue = value; }
            }
    
            public WinInetErrors StatusCode
            {
                get { return statusCodeValue; }
                set { statusCodeValue = value; }
            }
    
            public Boolean Cancel
            {
                get { return cancelValue; }
                set { cancelValue = value; }
            }
        }
    
        // Imports the NavigateError method from the OLE DWebBrowserEvents2 
        // interface. 
        [ComImport, Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D"),
        InterfaceType(ComInterfaceType.InterfaceIsIDispatch),
        TypeLibType(TypeLibTypeFlags.FHidden)]
        public interface DWebBrowserEvents2
        {
            [DispId(271)]
            void NavigateError(
                [In, MarshalAs(UnmanagedType.IDispatch)] object pDisp,
                [In] ref object URL, [In] ref object frame,
                [In] ref object statusCode, [In, Out] ref bool cancel);
        }
    ---------------------------
     public enum WinInetErrors : int
            {
                HTTP_STATUS_CONTINUE = 100, //The request can be continued.
                HTTP_STATUS_SWITCH_PROTOCOLS = 101, //The server has switched protocols in an upgrade header.
                HTTP_STATUS_OK = 200, //The request completed successfully.
                HTTP_STATUS_CREATED = 201, //The request has been fulfilled and resulted in the creation of a new resource.
                HTTP_STATUS_ACCEPTED = 202, //The request has been accepted for processing, but the processing has not been completed.
                HTTP_STATUS_PARTIAL = 203, //The returned meta information in the entity-header is not the definitive set available from the origin server.
                HTTP_STATUS_NO_CONTENT = 204, //The server has fulfilled the request, but there is no new information to send back.
                HTTP_STATUS_RESET_CONTENT = 205, //The request has been completed, and the client program should reset the document view that caused the request to be sent to allow the user to easily initiate another input action.
                HTTP_STATUS_PARTIAL_CONTENT = 206, //The server has fulfilled the partial GET request for the resource.
                HTTP_STATUS_AMBIGUOUS = 300, //The server couldn't decide what to return.
                HTTP_STATUS_MOVED = 301, //The requested resource has been assigned to a new permanent URI (Uniform Resource Identifier), and any future references to this resource should be done using one of the returned URIs.
                HTTP_STATUS_REDIRECT = 302, //The requested resource resides temporarily under a different URI (Uniform Resource Identifier).
                HTTP_STATUS_REDIRECT_METHOD = 303, //The response to the request can be found under a different URI (Uniform Resource Identifier) and should be retrieved using a GET HTTP verb on that resource.
                HTTP_STATUS_NOT_MODIFIED = 304, //The requested resource has not been modified.
                HTTP_STATUS_USE_PROXY = 305, //The requested resource must be accessed through the proxy given by the location field.
                HTTP_STATUS_REDIRECT_KEEP_VERB = 307, //The redirected request keeps the same HTTP verb. HTTP/1.1 behavior.
    
                HTTP_STATUS_BAD_REQUEST = 400,
                HTTP_STATUS_DENIED = 401,
                HTTP_STATUS_PAYMENT_REQ = 402,
                HTTP_STATUS_FORBIDDEN = 403,
                HTTP_STATUS_NOT_FOUND = 404,
                HTTP_STATUS_BAD_METHOD = 405,
                HTTP_STATUS_NONE_ACCEPTABLE = 406,
                HTTP_STATUS_PROXY_AUTH_REQ = 407,
                HTTP_STATUS_REQUEST_TIMEOUT = 408,
                HTTP_STATUS_CONFLICT = 409,
                HTTP_STATUS_GONE = 410,
                HTTP_STATUS_LENGTH_REQUIRED = 411,
                HTTP_STATUS_PRECOND_FAILED = 412,
                HTTP_STATUS_REQUEST_TOO_LARGE = 413,
                HTTP_STATUS_URI_TOO_LONG = 414,
                HTTP_STATUS_UNSUPPORTED_MEDIA = 415,
                HTTP_STATUS_RETRY_WITH = 449,
                HTTP_STATUS_SERVER_ERROR = 500,
                HTTP_STATUS_NOT_SUPPORTED = 501,
                HTTP_STATUS_BAD_GATEWAY = 502,
                HTTP_STATUS_SERVICE_UNAVAIL = 503,
                HTTP_STATUS_GATEWAY_TIMEOUT = 504,
                HTTP_STATUS_VERSION_NOT_SUP = 505,
    
                ERROR_INTERNET_ASYNC_THREAD_FAILED = 12047,    //The application could not start an asynchronous thread.
                ERROR_INTERNET_BAD_AUTO_PROXY_SCRIPT = 12166,    //There was an error in the automatic proxy configuration script.
                ERROR_INTERNET_BAD_OPTION_LENGTH = 12010,    //The length of an option supplied to InternetQueryOption or InternetSetOption is incorrect for the type of option specified.
                ERROR_INTERNET_BAD_REGISTRY_PARAMETER = 12022,    //A required registry value was located but is an incorrect type or has an invalid value.
                ERROR_INTERNET_CANNOT_CONNECT = 12029,    //The attempt to connect to the server failed.
                ERROR_INTERNET_CHG_POST_IS_NON_SECURE = 12042,    //The application is posting and attempting to change multiple lines of text on a server that is not secure.
                ERROR_INTERNET_CLIENT_AUTH_CERT_NEEDED = 12044,    //The server is requesting client authentication.
                ERROR_INTERNET_CLIENT_AUTH_NOT_SETUP = 12046,    //Client authorization is not set up on this computer.
                ERROR_INTERNET_CONNECTION_ABORTED = 12030,    //The connection with the server has been terminated.
                ERROR_INTERNET_CONNECTION_RESET = 12031,    //The connection with the server has been reset.
                ERROR_INTERNET_DIALOG_PENDING = 12049,    //Another thread has a password dialog box in progress.
                ERROR_INTERNET_DISCONNECTED = 12163,    //The Internet connection has been lost.
                ERROR_INTERNET_EXTENDED_ERROR = 12003,    //An extended error was returned from the server. This is typically a string or buffer containing a verbose error message. Call InternetGetLastResponseInfo to retrieve the error text.
                ERROR_INTERNET_FAILED_DUETOSECURITYCHECK = 12171,    //The function failed due to a security check.
                ERROR_INTERNET_FORCE_RETRY = 12032,    //The function needs to redo the request.
                ERROR_INTERNET_FORTEZZA_LOGIN_NEEDED = 12054,    //The requested resource requires Fortezza authentication.
                ERROR_INTERNET_HANDLE_EXISTS = 12036,    //The request failed because the handle already exists.
                ERROR_INTERNET_HTTP_TO_HTTPS_ON_REDIR = 12039,    //The application is moving from a non-SSL to an SSL connection because of a redirect.
                ERROR_INTERNET_HTTPS_HTTP_SUBMIT_REDIR = 12052,    //The data being submitted to an SSL connection is being redirected to a non-SSL connection.
                ERROR_INTERNET_HTTPS_TO_HTTP_ON_REDIR = 12040,    //The application is moving from an SSL to an non-SSL connection because of a redirect.
                ERROR_INTERNET_INCORRECT_FORMAT = 12027,    //The format of the request is invalid.
                ERROR_INTERNET_INCORRECT_HANDLE_STATE = 12019,    //The requested operation cannot be carried out because the handle supplied is not in the correct state.
                ERROR_INTERNET_INCORRECT_HANDLE_TYPE = 12018,    //The type of handle supplied is incorrect for this operation.
                ERROR_INTERNET_INCORRECT_PASSWORD = 12014,    //The request to connect and log on to an FTP server could not be completed because the supplied password is incorrect.
                ERROR_INTERNET_INCORRECT_USER_NAME = 12013,    //The request to connect and log on to an FTP server could not be completed because the supplied user name is incorrect.
                ERROR_INTERNET_INSERT_CDROM = 12053,    //The request requires a CD-ROM to be inserted in the CD-ROM drive to locate the resource requested.
                ERROR_INTERNET_INTERNAL_ERROR = 12004,    //An internal error has occurred.
                ERROR_INTERNET_INVALID_CA = 12045,    //The function is unfamiliar with the Certificate Authority that generated the server's certificate.
                ERROR_INTERNET_INVALID_OPERATION = 12016,    //The requested operation is invalid.
                ERROR_INTERNET_INVALID_OPTION = 12009,    //A request to InternetQueryOption or InternetSetOption specified an invalid option value.
                ERROR_INTERNET_INVALID_PROXY_REQUEST = 12033,    //The request to the proxy was invalid.
                ERROR_INTERNET_INVALID_URL = 12005,    //The URL is invalid.
                ERROR_INTERNET_ITEM_NOT_FOUND = 12028,    //The requested item could not be located.
                ERROR_INTERNET_LOGIN_FAILURE = 12015,    //The request to connect and log on to an FTP server failed.
                ERROR_INTERNET_LOGIN_FAILURE_DISPLAY_ENTITY_BODY = 12174,    //The MS-Logoff digest header has been returned from the Web site. This header specifically instructs the digest package to purge credentials for the associated realm. This error will only be returned if INTERNET_ERROR_MASK_LOGIN_FAILURE_DISPLAY_ENTITY_BODY has been set.
                ERROR_INTERNET_MIXED_SECURITY = 12041,    //The content is not entirely secure. Some of the content being viewed may have come from unsecured servers.
                ERROR_INTERNET_NAME_NOT_RESOLVED = 12007,    //The server name could not be resolved.
                ERROR_INTERNET_NEED_MSN_SSPI_PKG = 12173,    //Not currently implemented.
                ERROR_INTERNET_NEED_UI = 12034,    //A user interface or other blocking operation has been requested.
                ERROR_INTERNET_NO_CALLBACK = 12025,    //An asynchronous request could not be made because a callback function has not been set.
                ERROR_INTERNET_NO_CONTEXT = 12024,    //An asynchronous request could not be made because a zero context value was supplied.
                ERROR_INTERNET_NO_DIRECT_ACCESS = 12023,    //Direct network access cannot be made at this time.
                ERROR_INTERNET_NOT_INITIALIZED = 12172,    //Initialization of the WinINet API has not occurred. Indicates that a higher-level function, such as InternetOpen, has not been called yet.
                ERROR_INTERNET_NOT_PROXY_REQUEST = 12020,    //The request cannot be made via a proxy.
                ERROR_INTERNET_OPERATION_CANCELLED = 12017,    //The operation was canceled, usually because the handle on which the request was operating was closed before the operation completed.
                ERROR_INTERNET_OPTION_NOT_SETTABLE = 12011,    //The requested option cannot be set, only queried.
                ERROR_INTERNET_OUT_OF_HANDLES = 12001,    //No more handles could be generated at this time.
                ERROR_INTERNET_POST_IS_NON_SECURE = 12043,    //The application is posting data to a server that is not secure.
                ERROR_INTERNET_PROTOCOL_NOT_FOUND = 12008,    //The requested protocol could not be located.
                ERROR_INTERNET_PROXY_SERVER_UNREACHABLE = 12165,    //The designated proxy server cannot be reached.
                ERROR_INTERNET_REDIRECT_SCHEME_CHANGE = 12048,    //The function could not handle the redirection, because the scheme changed (for example, HTTP to FTP).
                ERROR_INTERNET_REGISTRY_VALUE_NOT_FOUND = 12021,    //A required registry value could not be located.
                ERROR_INTERNET_REQUEST_PENDING = 12026,    //The required operation could not be completed because one or more requests are pending.
                ERROR_INTERNET_RETRY_DIALOG = 12050,    //The dialog box should be retried.
                ERROR_INTERNET_SEC_CERT_CN_INVALID = 12038,    //SSL certificate common name (host name field) is incorrect—for example, if you entered www.server.com and the common name on the certificate says www.different.com.
                ERROR_INTERNET_SEC_CERT_DATE_INVALID = 12037,    //SSL certificate date that was received from the server is bad. The certificate is expired.
                ERROR_INTERNET_SEC_CERT_ERRORS = 12055,    //The SSL certificate contains errors.
                ERROR_INTERNET_SEC_CERT_NO_REV = 12056,
                ERROR_INTERNET_SEC_CERT_REV_FAILED = 12057,
                ERROR_INTERNET_SEC_CERT_REVOKED = 12170,    //SSL certificate was revoked.
                ERROR_INTERNET_SEC_INVALID_CERT = 12169,    //SSL certificate is invalid.
                ERROR_INTERNET_SECURITY_CHANNEL_ERROR = 12157,    //The application experienced an internal error loading the SSL libraries.
                ERROR_INTERNET_SERVER_UNREACHABLE = 12164,    //The Web site or server indicated is unreachable.
                ERROR_INTERNET_SHUTDOWN = 12012,    //WinINet support is being shut down or unloaded.
                ERROR_INTERNET_TCPIP_NOT_INSTALLED = 12159,    //The required protocol stack is not loaded and the application cannot start WinSock.
                ERROR_INTERNET_TIMEOUT = 12002,    //The request has timed out.
                ERROR_INTERNET_UNABLE_TO_CACHE_FILE = 12158,    //The function was unable to cache the file.
                ERROR_INTERNET_UNABLE_TO_DOWNLOAD_SCRIPT = 12167,    //The automatic proxy configuration script could not be downloaded. The INTERNET_FLAG_MUST_CACHE_REQUEST flag was set.
    
                INET_E_INVALID_URL = unchecked((int)0x800C0002),
                INET_E_NO_SESSION = unchecked((int)0x800C0003),
                INET_E_CANNOT_CONNECT = unchecked((int)0x800C0004),
                INET_E_RESOURCE_NOT_FOUND = unchecked((int)0x800C0005),
                INET_E_OBJECT_NOT_FOUND = unchecked((int)0x800C0006),
                INET_E_DATA_NOT_AVAILABLE = unchecked((int)0x800C0007),
                INET_E_DOWNLOAD_FAILURE = unchecked((int)0x800C0008),
                INET_E_AUTHENTICATION_REQUIRED = unchecked((int)0x800C0009),
                INET_E_NO_VALID_MEDIA = unchecked((int)0x800C000A),
                INET_E_CONNECTION_TIMEOUT = unchecked((int)0x800C000B),
                INET_E_DEFAULT_ACTION = unchecked((int)0x800C0011),
                INET_E_INVALID_REQUEST = unchecked((int)0x800C000C),
                INET_E_UNKNOWN_PROTOCOL = unchecked((int)0x800C000D),
                INET_E_QUERYOPTION_UNKNOWN = unchecked((int)0x800C0013),
                INET_E_SECURITY_PROBLEM = unchecked((int)0x800C000E),
                INET_E_CANNOT_LOAD_DATA = unchecked((int)0x800C000F),
                INET_E_CANNOT_INSTANTIATE_OBJECT = unchecked((int)0x800C0010),
                INET_E_REDIRECT_FAILED = unchecked((int)0x800C0014),
                INET_E_REDIRECT_TO_DIR = unchecked((int)0x800C0015),
                INET_E_CANNOT_LOCK_REQUEST = unchecked((int)0x800C0016),
                INET_E_USE_EXTEND_BINDING = unchecked((int)0x800C0017),
                INET_E_TERMINATED_BIND = unchecked((int)0x800C0018),
                INET_E_ERROR_FIRST = unchecked((int)0x800C0002),
                INET_E_CODE_DOWNLOAD_DECLINED = unchecked((int)0x800C0100),
                INET_E_RESULT_DISPATCHED = unchecked((int)0x800C0200),
                INET_E_CANNOT_REPLACE_SFP_FILE = unchecked((int)0x800C0300),
    
                HTTP_COOKIE_DECLINED = 12162,    //The HTTP cookie was declined by the server.
                HTTP_COOKIE_NEEDS_CONFIRMATION = 12161,    //The HTTP cookie requires confirmation.
                HTTP_DOWNLEVEL_SERVER = 12151,    //The server did not return any headers.
                HTTP_HEADER_ALREADY_EXISTS = 12155,    //The header could not be added because it already exists.
                HTTP_HEADER_NOT_FOUND = 12150,    //The requested header could not be located.
                HTTP_INVALID_HEADER = 12153,    //The supplied header is invalid.
                HTTP_INVALID_QUERY_REQUEST = 12154,    //The request made to HttpQueryInfo is invalid.
                HTTP_INVALID_SERVER_RESPONSE = 12152,    //The server response could not be parsed.
                HTTP_NOT_REDIRECTED = 12160,    //The HTTP request was not redirected.
                HTTP_REDIRECT_FAILED = 12156,    //The redirection failed because either the scheme changed (for example, HTTP to FTP) or all attempts made to redirect failed (default is five attempts).
                HTTP_REDIRECT_NEEDS_CONFIRMATION = 12168    //The redirection requires user confirmation.
            }
