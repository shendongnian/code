       Public Shared Function FromBlob(ByVal Id As String, ByVal Rv As String, ByVal cn As OracleConnection) As Proyecto
         Dim n As Integer, Prj As Proyecto = Nothing
         Dim Bf(2)() As Byte, arrAr(2) As IAsyncResult 'Para proceso asíncrono
    
         Dim Cmd As New OracleCommand( _
             "Select rv,fecha,Datos From Proyectos Where Id=:Id and Rv in (:Rv,'Av','Est')", cn)
         Cmd.BindByName = True
         Cmd.Parameters.Add("Id", OracleDbType.Varchar2, Id, ParameterDirection.Input)
         Cmd.Parameters.Add("Rv", OracleDbType.Varchar2, Rv, ParameterDirection.Input)
         If Rv Is Nothing Then Prj = Proyecto.Actprj
         Try
            Using Rdr As OracleDataReader = Cmd.ExecuteReader
                Do Until Rdr.Read = False
                    Dim rv1 As String = Rdr.GetString(0)
                    Select Case rv1
                        Case "Av" : n = 1   'Avance TND
                        Case "Est" : n = 2  'Datos Seguimiento Estudio Seguridad
                        Case Else : n = 0
                    End Select
                    If Rdr.IsDBNull(2) = False Then
                       Dim Blob As OracleBlob = Rdr.GetOracleBlob(2)
                       Dim Buffer(CInt(Blob.Length)) As Byte
                       Bf(n) = Buffer
                       arrAr(n) = Blob.BeginRead(Buffer, 0, Buffer.Length, Nothing, Blob)
                       'store.Entries.Add(Proyecto.Entry.FromLob(New BinReader(Blob))) 'Sincrono
                       'lob.Dispose()
                    End If
                Loop
                If Bf(0) Is Nothing AndAlso Prj Is Nothing Then _
                   MessageBox.Show("Fallo al cargar proyecto") : Return Nothing
                For n = 0 To Bf.Length - 1
                    Dim ar As IAsyncResult = arrAr(n)
                    If ar IsNot Nothing AndAlso ar.AsyncWaitHandle.WaitOne() Then
                       Dim blob As OracleBlob = DirectCast(ar.AsyncState, OracleBlob)
                       blob.EndRead(ar)
                       blob.Dispose()
                       If ar.IsCompleted Then
                          Using rd As New BinReader(New MemoryStream(Bf(n)))
                              If n = 0 Then
                                 Prj = New Proyecto(rd, False)
                              Else
                                 Dim entry = Proyecto.Entry.FromLob(rd), Index = Prj.IndexOf(entry)
                                 If Index < 0 Then Prj.Add(entry) Else Prj(Index) = entry
                              End If
                          End Using
                       End If
                    End If
                Next
            End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
         End Try
         Return Prj
      End Function
