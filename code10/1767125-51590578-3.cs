    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using BenchmarkDotNet.Attributes;
    namespace StackOverflow_51584129
    {
        [CategoriesColumn()]
        [GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByCategory)]
        public class StringCreationBenchmarks
        {
            private static readonly Encoding InputEncoding = Encoding.ASCII;
            private const string InputString = "132,29";
            private static readonly byte[] InputBytes = InputEncoding.GetBytes(InputString);
            private static readonly char[] InputChars = InputString.ToCharArray();
            private static readonly sbyte[] InputSBytes = InputBytes.Select(Convert.ToSByte).ToArray();
            private GCHandle _inputBytesHandle;
            private GCHandle _inputCharsHandle;
            private GCHandle _inputSBytesHandle;
            private StringBuilder _builder;
            [Benchmark(Baseline = true)]
            [BenchmarkCategory("char[] => string")]
            public string String_Constructor_CharArray()
            {
                return new string(InputChars);
            }
            [Benchmark(Baseline = true)]
            [BenchmarkCategory("void* => string")]
            public unsafe string String_Constructor_CharPointer()
            {
                var pointer = (char*) _inputCharsHandle.AddrOfPinnedObject();
                return new string(pointer);
            }
            [Benchmark()]
            [BenchmarkCategory("void* => string")]
            public unsafe string String_Constructor_SBytePointer()
            {
                var pointer = (sbyte*) _inputSBytesHandle.AddrOfPinnedObject();
                return new string(pointer);
            }
            [Benchmark()]
            [BenchmarkCategory("char[] => string")]
            public string String_Concat()
            {
                return string.Concat(InputChars);
            }
            [Benchmark()]
            [BenchmarkCategory("char[] => string")]
            public string StringBuilder_Local_AppendSingleChar_DefaultCapacity()
            {
                var builder = new StringBuilder();
                foreach (var c in InputChars)
                    builder.Append(c);
                return builder.ToString();
            }
            [Benchmark()]
            [BenchmarkCategory("char[] => string")]
            public string StringBuilder_Local_AppendSingleChar_ExactCapacity()
            {
                var builder = new StringBuilder(InputChars.Length);
                foreach (var c in InputChars)
                    builder.Append(c);
                return builder.ToString();
            }
            [Benchmark()]
            [BenchmarkCategory("char[] => string")]
            public string StringBuilder_Local_AppendAllChars_DefaultCapacity()
            {
                var builder = new StringBuilder().Append(InputChars);
                return builder.ToString();
            }
            [Benchmark()]
            [BenchmarkCategory("char[] => string")]
            public string StringBuilder_Local_AppendAllChars_ExactCapacity()
            {
                var builder = new StringBuilder(InputChars.Length).Append(InputChars);
                return builder.ToString();
            }
            [Benchmark()]
            [BenchmarkCategory("char[] => string")]
            public string StringBuilder_Field_AppendSingleChar()
            {
                _builder.Clear();
                foreach (var c in InputChars)
                    _builder.Append(c);
                return _builder.ToString();
            }
            [Benchmark()]
            [BenchmarkCategory("char[] => string")]
            public string StringBuilder_Field_AppendAllChars()
            {
                return _builder.Clear().Append(InputChars).ToString();
            }
            [Benchmark(Baseline = true)]
            [BenchmarkCategory("byte[] => string")]
            public string Encoding_GetString()
            {
                return InputEncoding.GetString(InputBytes);
            }
            [Benchmark()]
            [BenchmarkCategory("byte[] => string")]
            public string Encoding_GetChars_String_Constructor()
            {
                var chars = InputEncoding.GetChars(InputBytes);
                return new string(chars);
            }
            [Benchmark()]
            [BenchmarkCategory("byte[] => string")]
            public string SafeArrayCopy_String_Constructor()
            {
                var chars = new char[InputString.Length];
                for (int i = 0; i < InputString.Length; i++)
                    chars[i] = Convert.ToChar(InputBytes[i]);
                return new string(chars);
            }
            [Benchmark()]
            [BenchmarkCategory("void* => string")]
            public unsafe string UnsafeArrayCopy_String_Constructor()
            {
                fixed (char* chars = new char[InputString.Length])
                {
                    var bytes = (byte*) _inputBytesHandle.AddrOfPinnedObject();
                    for (int i = 0; i < InputString.Length; i++)
                        chars[i] = Convert.ToChar(bytes[i]);
                    return new string(chars);
                }
            }
            [GlobalSetup(Targets = new[] { nameof(StringBuilder_Field_AppendAllChars), nameof(StringBuilder_Field_AppendSingleChar) })]
            public void SetupStringBuilderField()
            {
                _builder = new StringBuilder();
            }
            [GlobalSetup(Target = nameof(UnsafeArrayCopy_String_Constructor))]
            public void SetupBytesHandle()
            {
                _inputBytesHandle = GCHandle.Alloc(InputBytes, GCHandleType.Pinned);
            }
            [GlobalCleanup(Target = nameof(UnsafeArrayCopy_String_Constructor))]
            public void CleanupBytesHandle()
            {
                _inputBytesHandle.Free();
            }
            [GlobalSetup(Target = nameof(String_Constructor_CharPointer))]
            public void SetupCharsHandle()
            {
                _inputCharsHandle = GCHandle.Alloc(InputChars, GCHandleType.Pinned);
            }
            [GlobalCleanup(Target = nameof(String_Constructor_CharPointer))]
            public void CleanupCharsHandle()
            {
                _inputCharsHandle.Free();
            }
            [GlobalSetup(Target = nameof(String_Constructor_SBytePointer))]
            public void SetupSByteHandle()
            {
                _inputSBytesHandle = GCHandle.Alloc(InputSBytes, GCHandleType.Pinned);
            }
            [GlobalCleanup(Target = nameof(String_Constructor_SBytePointer))]
            public void CleanupSByteHandle()
            {
                _inputSBytesHandle.Free();
            }
            public static void Main(string[] args)
            {
                BenchmarkDotNet.Running.BenchmarkRunner.Run<StringCreationBenchmarks>();
            }
        }
    }
