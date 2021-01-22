    Public Sub GetLogEntriesForApplication(ByVal settings As FilterSettings,
                                  Optional ByVal RowGovernor As Integer = -1)
        Dim command As New SqlCommand("GetApplicationActions", 
            New SqlConnection(m_environment.LoggingDatabaseConnectionString))
        Dim adapter As New SqlDataAdapter(command)
        Using command.Connection
            With command
                .Connection.Open()
                .CommandType = CommandType.StoredProcedure
                SqlCommandBuilder.DeriveParameters(command)
                With .Parameters
                    If settings.FilterOnLoggingLevel Then
                        If .Contains("@loggingLevel") Then
                            .Item("@loggingLevel").Value = settings.LoggingLevel
                        End If
                    End If
                    If settings.FilterOnApplicationID Then
                        If .Contains("@applicationID") Then
                            .Item("@applicationID").Value = settings.ApplicationID
                        End If
                    End If
                    If settings.FilterOnCreatedDate Then
                        If .Contains("@startDate") Then
                            .Item("@startDate").Value = settings.CreatedDate.Ticks
                        End If
                    End If
                    If settings.FilterOnEndDate Then
                        If .Contains("@endDate") Then
                            .Item("@endDate").Value = settings.EndDate.Ticks
                        End If
                    End If
                    If settings.FilterOnSuccess Then
                        If .Contains("@success") Then
                            .Item("@success").Value = settings.Success
                        End If
                    End If
                    If settings.FilterOnProcess Then
                        If settings.Process > -1 Then
                            If .Contains("@process") Then
                                .Item("@process").Value = settings.Process
                            End If
                        End If
                    End If
                    If RowGovernor > -1 Then
                        If .Contains("@topRows") Then
                            .Item("@topRows").Value = RowGovernor
                        End If
                    End If
                End With
            End With
            adapter.TableMappings.Clear()
            adapter.TableMappings.Add("Table", "ApplicationActions")
            adapter.TableMappings.Add("Table1", "Milestones")
            LogEntries.Clear()
            Milestones.Clear()
            adapter.Fill(m_logEntryData)
        End Using
    End Sub
