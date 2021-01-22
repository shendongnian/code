        using System;
        using System.Collections.Generic;
        using System.Text;
        using DirectShowLib;
        using System.Runtime.InteropServices;
        using System.IO;
        namespace ConvertBWF2WAV
        {
            public class BWF2WavConverter : ISampleGrabberCB
            {
                IFilterGraph2 gb = null;
                ICaptureGraphBuilder2 icgb = null;
                IBaseFilter ibfSrcFile = null;
                DsROTEntry m_rot = null;
                IMediaControl m_mediaCtrl = null;
                ISampleGrabber sg = null;
                public BWF2WavConverter() 
                { 
                    // Initialize
                    int hr;
                    icgb = (ICaptureGraphBuilder2)new CaptureGraphBuilder2();
                    gb = (IFilterGraph2) new FilterGraph();
                    sg = (ISampleGrabber)new SampleGrabber();
        #if DEBUG
                    m_rot = new DsROTEntry(gb);
        #endif
                    hr = icgb.SetFiltergraph(gb);
                    DsError.ThrowExceptionForHR(hr);
                }
                public void reset()
                {
                    gb = null;
                    icgb = null;
                    ibfSrcFile = null;
                    m_rot = null;
                    m_mediaCtrl = null;
                }
                public void convert(object obj) 
                {
                    string[] pair = obj as string[];
                    string srcfile = pair[0];
                    string targetfile = pair[1];
                    int hr;
                    ibfSrcFile = (IBaseFilter)new AsyncReader();
                    hr = gb.AddFilter(ibfSrcFile, "Reader");
                    DsError.ThrowExceptionForHR(hr);
                    IFileSourceFilter ifileSource = (IFileSourceFilter)ibfSrcFile;
                    hr = ifileSource.Load(srcfile, null);
                    DsError.ThrowExceptionForHR(hr);
                    // the guid is the one from ffdshow
                    Type fftype = Type.GetTypeFromCLSID(new Guid("0F40E1E5-4F79-4988-B1A9-CC98794E6B55"));
                    object ffdshow = Activator.CreateInstance(fftype);
                    hr = gb.AddFilter((IBaseFilter)ffdshow, "ffdshow");
                    DsError.ThrowExceptionForHR(hr);
                    // the guid is the one from the WAV Dest sample in the SDK
                    Type type = Type.GetTypeFromCLSID(new Guid("3C78B8E2-6C4D-11d1-ADE2-0000F8754B99"));
                    object wavedest = Activator.CreateInstance(type);
                    hr = gb.AddFilter((IBaseFilter)wavedest, "WAV Dest");
                    DsError.ThrowExceptionForHR(hr);
                    // manually tell the graph builder to try to hook up the pin that is left
                    IPin pWaveDestOut = null;
                    hr = icgb.FindPin(wavedest, PinDirection.Output, null, null, true, 0, out pWaveDestOut);
                    DsError.ThrowExceptionForHR(hr);
                    // render step 1
                    hr = icgb.RenderStream(null, null, ibfSrcFile, (IBaseFilter)ffdshow, (IBaseFilter)wavedest);
                    DsError.ThrowExceptionForHR(hr);
                     // Configure the sample grabber
                    IBaseFilter baseGrabFlt = sg as IBaseFilter;
                    ConfigSampleGrabber(sg);
                    IPin pGrabberIn = DsFindPin.ByDirection(baseGrabFlt, PinDirection.Input, 0);
                    IPin pGrabberOut = DsFindPin.ByDirection(baseGrabFlt, PinDirection.Output, 0);
                    hr = gb.AddFilter((IBaseFilter)sg, "SampleGrabber");
                    DsError.ThrowExceptionForHR(hr);
                    AMMediaType mediatype = new AMMediaType();
                    sg.GetConnectedMediaType(mediatype);
                    hr = gb.Connect(pWaveDestOut, pGrabberIn);
                    DsError.ThrowExceptionForHR(hr);
                    // file writer
                    FileWriter file_writer = new FileWriter();
                    IFileSinkFilter fs = (IFileSinkFilter)file_writer;
                    fs.SetFileName(targetfile, null);
                    hr = gb.AddFilter((DirectShowLib.IBaseFilter)file_writer, "File Writer");
                    DsError.ThrowExceptionForHR(hr);
                    // render step 2
                    AMMediaType mediatype2 = new AMMediaType();
                    pWaveDestOut.ConnectionMediaType(mediatype2);
                    gb.Render(pGrabberOut);
                    // alternatively to the file writer use the NullRenderer() to just discard the rest
                    // assign control
                    m_mediaCtrl = gb as IMediaControl;
                    // run
                    hr = m_mediaCtrl.Run();
                    DsError.ThrowExceptionForHR(hr);
                }
                //
                // configure the SampleGrabber filter of the graph
                //
                void ConfigSampleGrabber(ISampleGrabber sampGrabber)
                {
                    AMMediaType media;
                    // set the media type. works with "stream" somehow...
                    media = new AMMediaType();
                    media.majorType = MediaType.Stream;
                    //media.subType = MediaSubType.WAVE;
                    //media.formatType = FormatType.WaveEx;
                    // that's the call to the ISampleGrabber interface
                    sg.SetMediaType(media);
                    DsUtils.FreeAMMediaType(media);
                    media = null;
                    // set BufferCB as the desired Callback function
                    sg.SetCallback(this, 1);
                }
                public int SampleCB(double a, IMediaSample b)
                {
                    return 0;
                }
                /// <summary>
                /// Called on each SampleGrabber hit.
                /// </summary>
                /// <param name="SampleTime">Starting time of the sample, in seconds.</param>
                /// <param name="pBuffer">Pointer to a buffer that contains the sample data.</param>
                /// <param name="BufferLen">Length of the buffer pointed to by pBuffer, in bytes.</param>
                /// <returns></returns>
                public int BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen)
                {
                    byte[] buffer = new byte[BufferLen];
                    Marshal.Copy(pBuffer, buffer, 0, BufferLen);
                    using (BinaryWriter binWriter = new BinaryWriter(File.Open(@"C:\directshowoutput.pcm", FileMode.Append)))
                    {
                        binWriter.Write(buffer);
                    }
                    return 0;
                }
            }
        }
