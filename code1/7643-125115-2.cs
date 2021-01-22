    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
    End Sub
    Private Sub RichTextBox1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBox1.SelectionChanged
        FindLine()
        Invalidate()
    End Sub
    Private Sub FindLine()
        Dim intChar As Integer
        intChar = RichTextBox1.GetCharIndexFromPosition(New Point(0, 0))
        intLine = RichTextBox1.GetLineFromCharIndex(intChar)
    End Sub
    Private Sub DrawLines(ByVal g As Graphics, ByVal intLine As Integer)
        Dim intCounter As Integer, intY As Integer
        g.Clear(Color.Black)
        intCounter = intLine + 1
        intY = 2
        Do
            g.DrawString(intCounter.ToString(), Font, Brushes.White, 3, intY)
            intCounter += 1
            intY += Font.Height + 1
            If intY > ClientRectangle.Height - 15 Then Exit Do
        Loop
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        DrawLines(e.Graphics, intLine)
    End Sub
    Private Sub RichTextBox1_VScroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBox1.VScroll
        FindLine()
        Invalidate()
    End Sub
    Private Sub RichTextBox1_UserScroll() Handles RichTextBox1.UserScroll
        FindLine()
        Invalidate()
    End Sub
