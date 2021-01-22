    ''' Free to use under GPL open source license!
    ''' </summary>
    Partial Public Class MainForm
        Inherits Form
        ''' <summary>
        ''' Timer Update (every 1 sec)
        ''' </summary>
        Private Const timerUpdate As Double = 1000
        ''' <summary>
        ''' Interface Storage
        ''' </summary>
        Private nicArr As NetworkInterface()
        ''' <summary>
        ''' Main Timer Object 
        ''' (we could use something more efficient such 
        ''' as interop calls to HighPerformanceTimers)
        ''' </summary>
        Private timer As Timer
        ''' <summary>
        ''' Constructor
        ''' </summary>
        Public Sub New()
            InitializeComponent()
            InitializeNetworkInterface()
            InitializeTimer()
        End Sub
        ''' <summary>
        ''' Initialize all network interfaces on this computer
        ''' </summary>
        Private Sub InitializeNetworkInterface()
            ' Grab all local interfaces to this computer
            nicArr = NetworkInterface.GetAllNetworkInterfaces()
            ' Add each interface name to the combo box
            For i As Integer = 0 To nicArr.Length - 1
                cmbInterface.Items.Add(nicArr(i).Name)
            Next
            ' Change the initial selection to the first interface
            cmbInterface.SelectedIndex = 0
        End Sub
        ''' <summary>
        ''' Initialize the Timer
        ''' </summary>
        Private Sub InitializeTimer()
            timer = New Timer()
            timer.Interval = CInt(timerUpdate)
            AddHandler timer.Tick, New EventHandler(AddressOf timer_Tick)
            'timer.Tick += New EventHandler(AddressOf timer_Tick)
            timer.Start()
        End Sub
        
        ''' <summary>
        ''' Update GUI components for the network interfaces
        ''' </summary>
        Private Sub UpdateNetworkInterface()
            ' Grab NetworkInterface object that describes the current interface
            Dim nic As NetworkInterface = nicArr(cmbInterface.SelectedIndex)
            ' Grab the stats for that interface
            Dim interfaceStats As IPv4InterfaceStatistics = nic.GetIPv4Statistics()
            Dim BS As Double = CDbl(lblBytesSent.Text) * 1024 * 1024
            Dim bytesSentSpeed As Double = (interfaceStats.BytesSent - BS) / 1024
            Dim BR As Double = CDbl(lblBytesReceived.Text) * 1024 * 1024
            Dim bytesReceivedSpeed As Double = (interfaceStats.BytesReceived - BR) / 1024
            ' Update the labels
            lblSpeed.Text = CInt(((nic.Speed) / 1024) / 1024).ToString() + " Mbs"
            lblInterfaceType.Text = nic.NetworkInterfaceType.ToString()
            'lblSpeed.Text = nic.Speed.ToString()
            lblBytesReceived.Text = ((CInt(interfaceStats.BytesReceived / 1024) / 1024)).ToString()
            lblBytesSent.Text = ((CInt(interfaceStats.BytesSent.ToString() / 1024) / 1024)).ToString()
            lblTimeStamp.Text = Date.Now().ToString()
            lblDescription.Text = nic.Description.ToString()
            lblPhyAddorMAC.Text = nic.GetPhysicalAddress().ToString()
            lblName.Text = nic.Name.ToString()
            lblIPStatistics.Text = nic.Id.ToString()
            lblUpload.Text = bytesSentSpeed.ToString() + " KB/s"
            lblDownload.Text = bytesReceivedSpeed.ToString() + " KB/s"
        End Sub
        ''' <summary>
        ''' The Timer event for each Tick (second) to update the UI
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub timer_Tick(sender As Object, e As EventArgs)
            UpdateNetworkInterface()
        End Sub
        Friend WithEvents cmbInterface As System.Windows.Forms.ComboBox
        Friend WithEvents lblSpeed As System.Windows.Forms.Label
        Friend WithEvents lblInterfaceType As System.Windows.Forms.Label
        Friend WithEvents lblBytesReceived As System.Windows.Forms.Label
        Friend WithEvents lblBytesSent As System.Windows.Forms.Label
        Friend WithEvents lblUpload As System.Windows.Forms.Label
        Friend WithEvents Timer1 As System.Windows.Forms.Timer
        Private components As System.ComponentModel.IContainer
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.cmbInterface = New System.Windows.Forms.ComboBox()
            Me.lblSpeed = New System.Windows.Forms.Label()
            Me.lblInterfaceType = New System.Windows.Forms.Label()
            Me.lblBytesReceived = New System.Windows.Forms.Label()
            Me.lblBytesSent = New System.Windows.Forms.Label()
            Me.lblUpload = New System.Windows.Forms.Label()
            Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
            Me.lblDownload = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.lblTimeStamp = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblDescription = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lblPhyAddorMAC = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.lblName = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lblIPStatistics = New System.Windows.Forms.Label()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'cmbInterface
            '
            Me.cmbInterface.FormattingEnabled = True
            Me.cmbInterface.Location = New System.Drawing.Point(139, 24)
            Me.cmbInterface.Name = "cmbInterface"
            Me.cmbInterface.Size = New System.Drawing.Size(232, 21)
            Me.cmbInterface.TabIndex = 0
            '
            'lblSpeed
            '
            Me.lblSpeed.AutoSize = True
            Me.lblSpeed.Location = New System.Drawing.Point(136, 60)
            Me.lblSpeed.Name = "lblSpeed"
            Me.lblSpeed.Size = New System.Drawing.Size(13, 13)
            Me.lblSpeed.TabIndex = 1
            Me.lblSpeed.Text = "0"
            '
            'lblInterfaceType
            '
            Me.lblInterfaceType.AutoSize = True
            Me.lblInterfaceType.Location = New System.Drawing.Point(136, 84)
            Me.lblInterfaceType.Name = "lblInterfaceType"
            Me.lblInterfaceType.Size = New System.Drawing.Size(13, 13)
            Me.lblInterfaceType.TabIndex = 1
            Me.lblInterfaceType.Text = "0"
            '
            'lblBytesReceived
            '
            Me.lblBytesReceived.AutoSize = True
            Me.lblBytesReceived.Location = New System.Drawing.Point(136, 112)
            Me.lblBytesReceived.Name = "lblBytesReceived"
            Me.lblBytesReceived.Size = New System.Drawing.Size(13, 13)
            Me.lblBytesReceived.TabIndex = 1
            Me.lblBytesReceived.Text = "0"
            '
            'lblBytesSent
            '
            Me.lblBytesSent.AutoSize = True
            Me.lblBytesSent.Location = New System.Drawing.Point(136, 142)
            Me.lblBytesSent.Name = "lblBytesSent"
            Me.lblBytesSent.Size = New System.Drawing.Size(13, 13)
            Me.lblBytesSent.TabIndex = 1
            Me.lblBytesSent.Text = "0"
            '
            'lblUpload
            '
            Me.lblUpload.AutoSize = True
            Me.lblUpload.Location = New System.Drawing.Point(136, 175)
            Me.lblUpload.Name = "lblUpload"
            Me.lblUpload.Size = New System.Drawing.Size(13, 13)
            Me.lblUpload.TabIndex = 1
            Me.lblUpload.Text = "0"
            '
            'lblDownload
            '
            Me.lblDownload.AutoSize = True
            Me.lblDownload.Location = New System.Drawing.Point(136, 202)
            Me.lblDownload.Name = "lblDownload"
            Me.lblDownload.Size = New System.Drawing.Size(13, 13)
            Me.lblDownload.TabIndex = 1
            Me.lblDownload.Text = "0"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(12, 60)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(38, 13)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Speed"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(12, 84)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(73, 13)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "InterfaceType"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(12, 112)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(82, 13)
            Me.Label3.TabIndex = 1
            Me.Label3.Text = "Bytes Received"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(12, 142)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(58, 13)
            Me.Label4.TabIndex = 1
            Me.Label4.Text = "Bytes Sent"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(12, 175)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(73, 13)
            Me.Label5.TabIndex = 1
            Me.Label5.Text = "Upload speed"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(12, 202)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(87, 13)
            Me.Label6.TabIndex = 1
            Me.Label6.Text = "Download speed"
            '
            'lblTimeStamp
            '
            Me.lblTimeStamp.AutoSize = True
            Me.lblTimeStamp.Location = New System.Drawing.Point(116, 369)
            Me.lblTimeStamp.Name = "lblTimeStamp"
            Me.lblTimeStamp.Size = New System.Drawing.Size(13, 13)
            Me.lblTimeStamp.TabIndex = 1
            Me.lblTimeStamp.Text = "0"
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(17, 369)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(60, 13)
            Me.Label8.TabIndex = 1
            Me.Label8.Text = "TimeStamp"
            '
            'lblDescription
            '
            Me.lblDescription.AutoSize = True
            Me.lblDescription.Location = New System.Drawing.Point(136, 232)
            Me.lblDescription.Name = "lblDescription"
            Me.lblDescription.Size = New System.Drawing.Size(13, 13)
            Me.lblDescription.TabIndex = 1
            Me.lblDescription.Text = "0"
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(12, 232)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(60, 13)
            Me.Label9.TabIndex = 1
            Me.Label9.Text = "Description"
            '
            'lblPhyAddorMAC
            '
            Me.lblPhyAddorMAC.AutoSize = True
            Me.lblPhyAddorMAC.Location = New System.Drawing.Point(136, 259)
            Me.lblPhyAddorMAC.Name = "lblPhyAddorMAC"
            Me.lblPhyAddorMAC.Size = New System.Drawing.Size(13, 13)
            Me.lblPhyAddorMAC.TabIndex = 1
            Me.lblPhyAddorMAC.Text = "0"
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(12, 259)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(82, 13)
            Me.Label10.TabIndex = 1
            Me.Label10.Text = "PhyAdd or MAC"
            '
            'lblName
            '
            Me.lblName.AutoSize = True
            Me.lblName.Location = New System.Drawing.Point(136, 288)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(13, 13)
            Me.lblName.TabIndex = 1
            Me.lblName.Text = "0"
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(12, 288)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(35, 13)
            Me.Label11.TabIndex = 1
            Me.Label11.Text = "Name"
            '
            'lblIPStatistics
            '
            Me.lblIPStatistics.AutoSize = True
            Me.lblIPStatistics.Location = New System.Drawing.Point(136, 312)
            Me.lblIPStatistics.Name = "lblIPStatistics"
            Me.lblIPStatistics.Size = New System.Drawing.Size(13, 13)
            Me.lblIPStatistics.TabIndex = 1
            Me.lblIPStatistics.Text = "0"
            '
            'Label13
            '
            Me.Label13.AutoSize = True
            Me.Label13.Location = New System.Drawing.Point(12, 312)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(39, 13)
            Me.Label13.TabIndex = 1
            Me.Label13.Text = "NIC ID"
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(9, 32)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(30, 13)
            Me.Label7.TabIndex = 1
            Me.Label7.Text = "NICs"
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(321, 112)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(23, 13)
            Me.Label12.TabIndex = 1
            Me.Label12.Text = "MB"
            '
            'Label14
            '
            Me.Label14.AutoSize = True
            Me.Label14.Location = New System.Drawing.Point(321, 142)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(23, 13)
            Me.Label14.TabIndex = 1
            Me.Label14.Text = "MB"
            '
            'MainForm
            '
            Me.ClientSize = New System.Drawing.Size(660, 422)
            Me.Controls.Add(Me.Label13)
            Me.Controls.Add(Me.lblIPStatistics)
            Me.Controls.Add(Me.Label11)
            Me.Controls.Add(Me.lblName)
            Me.Controls.Add(Me.Label10)
            Me.Controls.Add(Me.lblPhyAddorMAC)
            Me.Controls.Add(Me.Label9)
            Me.Controls.Add(Me.lblDescription)
            Me.Controls.Add(Me.Label8)
            Me.Controls.Add(Me.lblTimeStamp)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.lblDownload)
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.lblUpload)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.lblBytesSent)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label14)
            Me.Controls.Add(Me.Label12)
            Me.Controls.Add(Me.lblBytesReceived)
            Me.Controls.Add(Me.Label7)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.lblInterfaceType)
            Me.Controls.Add(Me.lblSpeed)
            Me.Controls.Add(Me.cmbInterface)
            Me.Name = "MainForm"
            Me.Text = "Band Width Statistics"
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub
        Friend WithEvents lblDownload As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents lblTimeStamp As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents lblDescription As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents lblPhyAddorMAC As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents lblIPStatistics As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
    End Class
