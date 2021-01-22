    `Dim swfFile As Byte() = IO.File.ReadAllBytes("C:\Users\root\source\file.swf")
         Using stm As MemoryStream = New MemoryStream()
          Using writer As BinaryWriter = New BinaryWriter(stm)
             writer.Write(8 + swfFile.Length)
             writer.Write(&H55665566)
             writer.Write(swfFile.Length)
             writer.Write(swfFile)
             stm.Seek(0, SeekOrigin.Begin)
             AxShockwaveFlash1.OcxState = New AxHost.State(stm, 1, False, Nothing)
          End Using
         End Using`
