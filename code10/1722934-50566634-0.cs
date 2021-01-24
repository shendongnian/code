    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using System.Text;
    
    namespace CountLinesVSIX
    	{
    	[PackageRegistration(UseManagedResourcesOnly = true)]
        [InstalledProductRegistration( "CountLines", "Generate XML with line count", "1.0")] 
        [Guid("202E7E8B-557E-46CB-8A1D-3024AD68F44A")]
        [ComVisible(true)]
        [ProvideObject(typeof(CountLines))]
        [CodeGeneratorRegistration(typeof(CountLines), "CountLines", "{FAE04EC1-301F-11D3-BF4B-00C04F79EFBC}", GeneratesDesignTimeSource = true)]
        public sealed class CountLines : IVsSingleFileGenerator
        {
            
            #region IVsSingleFileGenerator Members
    
            public int DefaultExtension(out string pbstrDefaultExtension)
            {
                pbstrDefaultExtension = ".xml";
                return pbstrDefaultExtension.Length;
            }
    
            public int Generate(string wszInputFilePath, string bstrInputFileContents,
              string wszDefaultNamespace, IntPtr[] rgbOutputFileContents,
              out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
            {
                try
                {
                    int lineCount = bstrInputFileContents.Split('\n').Length;
                    byte[] bytes = Encoding.UTF8.GetBytes("<LineCount>" + lineCount.ToString() + "</LineCount>" );
                    int length = bytes.Length;
                    rgbOutputFileContents[0] = Marshal.AllocCoTaskMem(length);
                    Marshal.Copy(bytes, 0, rgbOutputFileContents[0], length);
                    pcbOutput = (uint)length;
                }
                catch (Exception ex)
                {
                    pcbOutput = 0;
                }
                return VSConstants.S_OK;
            }
    
            #endregion
        }
    }
