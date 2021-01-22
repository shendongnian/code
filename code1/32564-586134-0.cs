    Imports System.Drawing.Drawing2D
    Imports System
    Imports System.Collections
    Imports System.ComponentModel
    Imports System.Data
    Imports System.Drawing
    Imports System.Drawing.Imaging
    Imports System.IO
    Imports System.Runtime.InteropServices
    Imports System.Windows.Forms
    
    Public Class ctlViewer
       Inherits Panel
    
       Protected Const C_SmallChangePercent As Integer = 2
       Protected Const C_LargeChangePercent As Integer = 10
    
       Protected mimgImage As Image
       Protected mintActiveFrame As Integer
       Protected mdecZoom As Decimal
       Protected mpntUpperLeft As New Point
       Protected mpntCenter As New Point
       Protected mblnDragging As Boolean = False
       Protected mblnPanOnMouseMove As Boolean
       Protected mblnPanMouseButtons As MouseButtons
       Protected mcurPanMouseCursor As Cursor
       Private mButtons As MouseButtons
    
    #Region " Constructor"
       Public Sub New()
          MyBase.New()
          Me.SetStyle(ControlStyles.ContainerControl, False)
          Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
          Me.SetStyle(ControlStyles.UserPaint, True)
          Me.SetStyle(ControlStyles.ResizeRedraw, True)
          Me.SetStyle(ControlStyles.UserPaint, True)
          Me.SetStyle(ControlStyles.DoubleBuffer, True)
          ZoomFactor = 1.0
          Me.AutoScroll = True
          Me.BackColor = Color.FromKnownColor(KnownColor.ControlDark)
       End Sub
    #End Region
    
    #Region " Properties"
    
       ''' <summary>
       ''' Image object representing the TIFF image.
       ''' </summary>
       ''' <value></value>
       ''' <returns></returns>
       ''' <remarks></remarks>
       Public Property Image() As Image
          Get
             Return mimgImage
          End Get
          Set(ByVal Value As Image)
             AutoScrollPosition = New Point(0, 0)
             mimgImage = Value
             RaiseEvent ImageLoaded(New ImageLoadedEventArgs(Value))
             UpdateScaleFactor()
             Invalidate()
          End Set
       End Property
    
       ''' <summary>
       ''' Should the image be panned when mouse buttons are pressed
       ''' </summary>
       ''' <value></value>
       ''' <returns></returns>
       ''' <remarks></remarks>
       Public Property PanMouseButtons() As MouseButtons
          Get
             Return mblnPanMouseButtons
          End Get
          Set(ByVal Value As MouseButtons)
             mblnPanMouseButtons = Value
          End Set
       End Property
    
       ''' <summary>
       ''' Cursor being used to cue the user that the image is being panned.
       ''' </summary>
       ''' <value></value>
       ''' <returns></returns>
       ''' <remarks></remarks>
       Public Property PanMouseCursor() As Cursor
          Get
             Return Me.mcurPanMouseCursor
          End Get
          Set(ByVal Value As Cursor)
             mcurPanMouseCursor = Value
          End Set
       End Property
    
       ''' <summary>
       ''' Should the image be panned when the mouse moves?
       ''' </summary>
       ''' <value></value>
       ''' <returns></returns>
       ''' <remarks></remarks>
       Public Property PanOnMouseMove() As Boolean
          Get
             Return Me.mblnPanOnMouseMove
          End Get
          Set(ByVal Value As Boolean)
             mblnPanOnMouseMove = Value
          End Set
       End Property
    
       ''' <summary>
       ''' Viewing area of image
       ''' </summary>
       ''' <value></value>
       ''' <returns></returns>
       ''' <remarks></remarks>
       Public ReadOnly Property ViewPort() As Rectangle
          Get
             Dim r As New Rectangle
             Dim pul As Point = Me.CoordViewerToSrc(New Point(0, 0))
             Dim pbr As Point = Me.CoordViewerToSrc(New Point(Me.Width, Me.Height))
             r.Location = pul
             r.Width = pbr.X - pul.X
             r.Height = pbr.Y - pul.Y
             Return r
          End Get
       End Property
    
       ''' <summary>
       ''' Gets or sets the zoom / scale factor for the image being displayed.
       ''' </summary>
       ''' <value></value>
       ''' <returns></returns>
       ''' <remarks></remarks>
       Public Property ZoomFactor() As Decimal
          Get
             Return mdecZoom
          End Get
          Set(ByVal Value As Decimal)
             If Value < 0 OrElse Value < 0.00001 Then
                Value = 0.00001F
             End If
             mdecZoom = Value
             UpdateScaleFactor()
             Invalidate()
             RaiseEvent ZoomChanged(New ImageViewerEventArgs(Me.Image))
          End Set
       End Property
    
    #End Region
    
    #Region " Event Signatures"
       Public Event ImageMouseDown(ByVal e As ImageMouseEventArgs)
       Public Event ImageMouseMove(ByVal e As ImageMouseEventArgs)
       Public Event ImageMouseUp(ByVal e As ImageMouseEventArgs)
       Public Event ImageLoaded(ByVal e As ImageLoadedEventArgs)
       Public Event ZoomChanged(ByVal e As ImageViewerEventArgs)
       Public Event ImageViewPortChanged(ByVal e As ImageViewerEventArgs)
    
       Public Event ViewerPaint(ByVal sender As Object, ByVal e As PaintEventArgs)
    #End Region
    
    #Region " Public Subs/Functions"
    
       ''' <summary>
       ''' Pans the viewer by X,Y up to the bounds of the image.
       ''' </summary>
       ''' <param name="x"></param>
       ''' <param name="y"></param>
       ''' <remarks></remarks>
       Public Sub Pan(ByVal x As Integer, ByVal y As Integer)
          Me.AutoScrollPosition = New Point(Math.Abs(Me.AutoScrollPosition.X) + x, Math.Abs(Me.AutoScrollPosition.Y) + y)
          Me.Invalidate()
       End Sub
    
       ''' <summary>
       ''' Zoom image
       ''' </summary>
       ''' <param name="decZoom"></param>
       ''' <remarks></remarks>
       Public Sub Zoom(ByVal decZoom As Decimal)
          ZoomFactor = decZoom
       End Sub
    
       ''' <summary>
       ''' Zoom image and scroll to rectangle coordinates.
       ''' </summary>
       ''' <param name="decZoomFactor"></param>
       ''' <param name="objRectangleToCenter"></param>
       ''' <remarks></remarks>
       Public Sub Zoom(ByVal decZoomFactor As Decimal, ByVal objRectangleToCenter As Rectangle)
          Dim intCenterX As Int32 = objRectangleToCenter.X + objRectangleToCenter.Width / 2
          Dim intCenterY As Int32 = objRectangleToCenter.Y + objRectangleToCenter.Height / 2
          Me.CenterOn(New Point(intCenterX, intCenterY))
          Me.ZoomFactor = decZoomFactor
       End Sub
    
       ''' <summary>
       ''' Zoom to fit image on screen.
       ''' </summary>
       ''' <param name="minZoom"></param>
       ''' <param name="maxZoom"></param>
       ''' <remarks></remarks>
       Public Sub ZoomToFit(ByVal minZoom As Decimal, ByVal maxZoom As Decimal)
          If Not Me.Image Is Nothing Then
             Dim ItoVh As Single = Me.Image.Height / (Me.Height - 2)
             Dim ItoVw As Single = Me.Image.Width / (Me.Width - 2)
             Dim zf As Single = 1 / Math.Max(ItoVh, ItoVw)
             If (((zf > minZoom) And minZoom <> 0) Or minZoom = 0) _
                   And ((zf < maxZoom) And maxZoom <> 0) Or maxZoom = 0 Then
                Me.Zoom(zf)
             End If
          End If
       End Sub
    
       ''' <summary>
       ''' Zoom to fit width of image
       ''' </summary>
       ''' <param name="minZoom"></param>
       ''' <param name="maxZoom"></param>
       ''' <remarks></remarks>
       Public Sub ZoomToWidth(ByVal minZoom As Decimal, ByVal maxZoom As Decimal)
          If Image Is Nothing Then
             Me.AutoScrollMargin = Me.Size
             Me.AutoScrollMinSize = Me.Size
    
             mpntCenter = New Point(0, 0)
             mpntUpperLeft = New Point(0, 0)
             Exit Sub
          End If
          Dim intOff As Integer = 0
          If ScrollStateVScrollVisible Then
             intOff = ScrollStateVScrollVisible
          End If
          Dim ItoVw As Single = Me.Image.Width / (Me.Width - 2)
          Dim zf As Single = 1 / ItoVw
          If (Me.Image.Height * zf) >= Me.Height Then
             ItoVw = Me.Image.Width / (Me.Width - 22)
             zf = 1 / ItoVw
          End If
          If (((zf > minZoom) And minZoom <> 0) Or minZoom = 0) _
                And ((zf < maxZoom) And maxZoom <> 0) Or maxZoom = 0 Then
             Me.Zoom(zf)
          End If
       End Sub
    
       ''' <summary>
       ''' Adjust scrollbars to zoomed size of image
       ''' </summary>
       ''' <remarks></remarks>
       Protected Sub UpdateScaleFactor()
          If Image Is Nothing Then
             Me.AutoScrollMargin = Me.Size
             Me.AutoScrollMinSize = Me.Size
    
             mpntCenter = New Point(0, 0)
             mpntUpperLeft = New Point(0, 0)
          Else
             Me.AutoScrollMinSize = New Size(CInt(Me.Image.Width * ZoomFactor + 0.5F), CInt(Me.Image.Height * ZoomFactor + 0.5F))
          End If
          Me.HorizontalScroll.LargeChange = Me.Size.Width * (C_LargeChangePercent / 100)
          Me.VerticalScroll.LargeChange = Me.Size.Height * (C_LargeChangePercent / 100)
          Me.HorizontalScroll.SmallChange = Me.Size.Width * (C_SmallChangePercent / 100)
          Me.VerticalScroll.SmallChange = Me.Size.Height * (C_SmallChangePercent / 100)
       End Sub
    
       ''' <summary>
       ''' Convert a point of the original image to screen coordinates adjusted for zoom and pan.
       ''' </summary>
       ''' <param name="pntPoint"></param>
       ''' <returns></returns>
       ''' <remarks></remarks>
       Public Function CoordSrcToViewer(ByVal pntPoint As Point) As Point
          Dim pntResult As New Point
          pntResult.X = pntPoint.X * Me.ZoomFactor + Me.AutoScrollPosition.X
          pntResult.Y = pntPoint.Y * Me.ZoomFactor + Me.AutoScrollPosition.Y
          Return pntResult
       End Function
    
       ''' <summary>
       ''' Convert a screen point to the corrseponding coordinate of the original image.
       ''' </summary>
       ''' <param name="pntPoint"></param>
       ''' <returns></returns>
       ''' <remarks></remarks>
       Public Function CoordViewerToSrc(ByVal pntPoint As Point) As Point
          Dim pntResult As New Point
          pntResult.X = (pntPoint.X - Me.AutoScrollPosition.X) / Me.ZoomFactor
          pntResult.Y = (pntPoint.Y - Me.AutoScrollPosition.Y) / Me.ZoomFactor
          Return pntResult
       End Function
    
       ''' <summary>
       ''' Returns an offset needed to move the center point to make visible.
       ''' </summary>
       ''' <param name="imagePoint"></param>
       ''' <returns></returns>
       ''' <remarks></remarks>
       Friend Function PointIsVisible(ByVal imagePoint As Point) As Point
          Dim pntViewer As Point = Me.CoordSrcToViewer(imagePoint)
          Dim pntSize As New Point((pntViewer.X - Me.Width) / Me.ZoomFactor, (pntViewer.Y - Me.Height) / Me.ZoomFactor)
          If pntViewer.X > 0 And pntViewer.X < Me.Width Then
             pntSize.X = 0
          End If
          If pntViewer.Y > 0 And pntViewer.Y < Me.Height Then
             pntSize.Y = 0
          End If
          If pntViewer.X < 0 Then
             pntSize.X = pntViewer.X
          End If
          If pntViewer.Y < 0 Then
             pntSize.Y = pntViewer.Y
          End If
          Return pntSize
       End Function
    
       ''' <summary>
       ''' Centers view on coordinates of the original image.
       ''' </summary>
       ''' <param name="X"></param>
       ''' <param name="Y"></param>
       ''' <remarks></remarks>
       Public Sub CenterOn(ByVal X As Integer, ByVal Y As Integer)
          CenterOn(New Point(X, Y))
       End Sub
    
       ''' <summary>
       ''' Centers view on a point of the original image.
       ''' </summary>
       ''' <param name="pntCenter"></param>
       ''' <remarks></remarks>
       Public Sub CenterOn(ByVal pntCenter As Point)
          Dim midX As Integer = Me.Width / 2
          Dim midY As Integer = Me.Height / 2
          Dim intX As Integer = (pntCenter.X * ZoomFactor - midX)
          Dim intY As Integer = (pntCenter.Y * ZoomFactor - midY)
          Me.AutoScrollPosition = New Point(intX, intY)
          Me.Invalidate()
       End Sub
    
       ''' <summary>
       ''' Returns image coordinate which is centered in viewer.
       ''' </summary>
       ''' <returns></returns>
       ''' <remarks></remarks>
       Public Function GetCenterPoint() As Point
          Dim pntResult As Point
          pntResult = CoordViewerToSrc(New Point(Me.Width / 2, Me.Height / 2))
          If pntResult.X > Me.Image.Width Or pntResult.Y > Image.Height Then
             pntResult = Nothing
          End If
          Return pntResult
       End Function
    
       ''' <summary>
       ''' Fire viewport changed event.
       ''' </summary>
       ''' <remarks></remarks>
       Private Sub FireViewPortChangedEvent()
          Dim e As New ImageViewerEventArgs(Me.Image)
          RaiseEvent ImageViewPortChanged(e)
       End Sub
       Private Sub FireViewerPaintEvent(ByVal e As PaintEventArgs)
          RaiseEvent ViewerPaint(Me, e)
       End Sub
    #End Region
    
    #Region " Overrides"
    
       ''' <summary>
       ''' Paint image in proper position and zoom.  All work is done with a Matrix object.
       ''' The coordinates of the graphics instance of the ctlViewer_OnPaint event 
       ''' are transformed.  This allows drawing on the "paper image" rather than "over the viewport"
       ''' </summary>
       ''' <param name="e"></param>
       ''' <remarks></remarks>
       Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
          If mimgImage Is Nothing Then
             MyBase.OnPaintBackground(e)
             Return
          Else
             Debug.WriteLine("ctl painting")
             Dim mx As New Matrix
             e.Graphics.FillRectangle(New SolidBrush(Me.BackColor), 0, 0, Me.Width, Me.Height)
             mx.Translate(Me.AutoScrollPosition.X, Me.AutoScrollPosition.Y)
             mx.Scale(ZoomFactor, ZoomFactor)
             e.Graphics.SetClip(New Rectangle(0, 0, Me.Width, Me.Height))
             e.Graphics.InterpolationMode = InterpolationMode.Low
             e.Graphics.SmoothingMode = SmoothingMode.HighSpeed
             e.Graphics.Transform = mx
             Dim ia As New ImageAttributes
             e.Graphics.DrawImage(Image, _
                 New Rectangle(-Me.AutoScrollPosition.X / ZoomFactor, _
                 -Me.AutoScrollPosition.Y / ZoomFactor, _
                  Me.Width / ZoomFactor, _
                  Me.Height / ZoomFactor), _
                  Me.ViewPort.Left, Me.ViewPort.Top, Me.ViewPort.Width, Me.ViewPort.Height, _
                 GraphicsUnit.Pixel, ia)
             ia.Dispose()
          End If
          Me.mpntCenter = Me.GetCenterPoint
          FireViewPortChangedEvent()
          MyBase.OnPaint(e)
          e.Graphics.ResetClip()
          e.Graphics.ResetTransform()
          Me.FireViewerPaintEvent(e)
    
       End Sub
    
       ''' <summary>
       ''' Pan image and raise event.
       ''' </summary>
       ''' <param name="e"></param>
       ''' <remarks></remarks>
       Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
          If PanOnMouseMove And e.Button = PanMouseButtons Then
             Me.Cursor = PanMouseCursor
          End If
          Me.mButtons = e.Button
          RaiseEvent ImageMouseDown(New ImageMouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta, Me.ZoomFactor, Me.AutoScrollPosition))
          MyBase.OnMouseDown(e)
       End Sub
    
       ''' <summary>
       ''' Stop panning image and raise event.
       ''' </summary>
       ''' <param name="e"></param>
       ''' <remarks></remarks>
       Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
          Me.Cursor = Cursors.Arrow
          MyBase.OnMouseUp(e)
    
          RaiseEvent ImageMouseUp(New ImageMouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta, Me.ZoomFactor, Me.AutoScrollPosition))
          Me.mButtons = Windows.Forms.MouseButtons.None
       End Sub
    
       ''' <summary>
       ''' Pan image if PanOnMouseMove is True.  Fire the ImageMouseMove event.
       ''' </summary>
       ''' <param name="e"></param>
       ''' <remarks></remarks>
       Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
          Static oldX As Integer
          Static oldy As Integer
          Try
             If Me.PanOnMouseMove And e.Button = Me.PanMouseButtons Then
                Dim xdiff As Integer = e.X - oldX
                Dim ydiff As Integer = e.Y - oldy
                AutoScrollPosition = New Point(Math.Abs(AutoScrollPosition.X) - xdiff, Math.Abs(AutoScrollPosition.Y) - ydiff)
                Invalidate()
             End If
             oldX = e.X
             oldy = e.Y
          Catch ex As Exception
             Throw ex
          Finally
             MyBase.OnMouseMove(e)
             RaiseEvent ImageMouseMove(New ImageMouseEventArgs(Me.mButtons, e.Clicks, e.X, e.Y, e.Delta, Me.ZoomFactor, Me.AutoScrollPosition))
          End Try
       End Sub
    
       ''' <summary>
       ''' Catch a panel scroll event.
       ''' </summary>
       ''' <param name="m"></param>
       ''' <remarks></remarks>
       Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
          Const WM_VSCROLL As Integer = 277 '115 hex
          Const WM_HSCROLL As Integer = 276 '0x114;
          MyBase.WndProc(m)
          If Not m.HWnd.Equals(Me.Handle) Then
             Return
          End If
          If m.Msg = WM_VSCROLL Or m.Msg = WM_HSCROLL Then
             Me.Invalidate()
          End If
       End Sub
    #End Region
    End Class
