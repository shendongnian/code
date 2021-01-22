    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;
    using IMAPI2;
    using ifs = IMAPI2FS;
    using MSDN.Samples.Imapi2;
    namespace Demo3
    {
        class Program
        {
            static void Main(string[] args)
            {
                // prepare the CFileSystemImage object and the event sink
                ifs.CFileSystemImage image = new IMAPI2FS.CFileSystemImage();
                CFileSystemImageEventHelper helper = new CFileSystemImageEventHelper(image);
                helper.Update += new IMAPI2FS.DFileSystemImageEvents_UpdateEventHandler(helper_Update);
                
                // Add some files to the image
                // Substitute with the path to your actual data
                image.Root.AddTree(@"c:\users\username\data", false);
                // Initialize a disc recorder
                string recorderID = new MsftDiscMaster2Class()[0];
                MsftDiscRecorder2Class recorder = new MsftDiscRecorder2Class();
                recorder.InitializeDiscRecorder(recorderID);
                // Prepare the DiscFormat2Data object
                MsftDiscFormat2DataClass fmtObj = new MsftDiscFormat2DataClass();
                // This is a workaround to address a type casting problem specific to .NET
                IDiscFormat2Data2 fmt = (IDiscFormat2Data2)fmtObj;
                fmtObj.Recorder = recorder;
                DDiscFormat2DataEventHelper fmtHelper = new DDiscFormat2DataEventHelper((MsftDiscFormat2DataClass)fmt);
                fmtHelper.Update += new DDiscFormat2DataEventHelper_UpdateEventHandler(fmtHelper_Update);
                ifs.IStream stm = image.CreateResultImage().ImageStream;
                // Write data
                fmt.Write((System.Runtime.InteropServices.ComTypes.IStream)stm);
            }
            static void fmtHelper_Update(IDiscFormat2Data @object, IDiscFormat2DataEventArgs args)
            {
                Console.WriteLine("{0}: Elapsed: {1}, Estimated: {2}", args.CurrentAction, args.ElapsedTime, args.TotalTime);
            }
            static void helper_Update(object @object, string currentFile, int copiedSectors, int totalSectors)
            {
                Console.WriteLine("Adding " + currentFile);
            }
        }
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [ComImport, Guid("2735413B-8F64-4B0F-8F00-5D77AFBE261E")]
        public interface IDiscFormat2Data2
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x888)]
            bool IsRecorderSupported([In, MarshalAs(UnmanagedType.Interface)] IDiscRecorder2 Recorder);
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x777)]
            bool IsCurrentMediaSupported([In, MarshalAs(UnmanagedType.Interface)] IDiscRecorder2 Recorder);
            [DispId(0x100)]
            IDiscRecorder2 Recorder { [return: MarshalAs(UnmanagedType.Interface)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x100)] get; [param: In, MarshalAs(UnmanagedType.Interface)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x100)] set; }
            [DispId(0x101)]
            bool BufferUnderrunFreeDisabled { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x101)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x101)] set; }
            [DispId(260)]
            bool PostgapAlreadyInImage { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(260)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(260)] set; }
            [DispId(0x105)]
            object[] SupportedMediaTypes { [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x105)] get; }
            [ComAliasName("imapi2.Interop.IMAPI_FORMAT2_DATA_MEDIA_STATE"), DispId(0x106)]
            IMAPI2.IMAPI_FORMAT2_DATA_MEDIA_STATE CurrentMediaStatus { [return: ComAliasName("imapi2.Interop.IMAPI_FORMAT2_DATA_MEDIA_STATE")] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x106)] get; }
            [DispId(0x107), ComAliasName("imapi2.Interop.IMAPI_MEDIA_WRITE_PROTECT_STATE")]
            IMAPI2.IMAPI_MEDIA_WRITE_PROTECT_STATE WriteProtectStatus { [return: ComAliasName("imapi2.Interop.IMAPI_MEDIA_WRITE_PROTECT_STATE")] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x107)] get; }
            [DispId(0x108)]
            int TotalSectorsOnMedia { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x108)] get; }
            [DispId(0x109)]
            int FreeSectorsOnMedia { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x109)] get; }
            [DispId(0x10a)]
            int NextWritableAddress { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x10a)] get; }
            [DispId(0x10b)]
            int StartAddressOfPreviousSession { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x10b)] get; }
            [DispId(0x10c)]
            int LastWrittenAddressOfPreviousSession { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x10c)] get; }
            [DispId(0x10d)]
            bool ForceMediaToBeClosed { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x10d)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x10d)] set; }
            [DispId(270)]
            bool DisableConsumerDvdCompatibilityMode { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(270)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(270)] set; }
            [ComAliasName("imapi2.Interop.IMAPI_MEDIA_PHYSICAL_TYPE"), DispId(0x10f)]
            IMAPI2.IMAPI_MEDIA_PHYSICAL_TYPE CurrentPhysicalMediaType { [return: ComAliasName("imapi2.Interop.IMAPI_MEDIA_PHYSICAL_TYPE")] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x10f)] get; }
            [DispId(0x110)]
            string ClientName { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x110)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x110)] set; }
            [DispId(0x111)]
            uint RequestedWriteSpeed { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x111)] get; }
            [DispId(0x112)]
            bool RequestedRotationTypeIsPureCAV { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x112)] get; }
            [DispId(0x113)]
            uint CurrentWriteSpeed { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x113)] get; }
            [DispId(0x114)]
            bool CurrentRotationTypeIsPureCAV { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x114)] get; }
            [DispId(0x115)]
            object[] SupportedWriteSpeeds { [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x115)] get; }
            [DispId(0x116)]
            object[] SupportedWriteSpeedDescriptors { [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x116)] get; }
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x200)]
            void Write([In, MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IStream data);
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x201)]
            void CancelWrite();
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x202)]
            void SetWriteSpeed([In] uint RequestedSectorsPerSecond, [In] bool RotationTypeIsPureCAV);
        }
    }
