    Imports System.Windows.Threading
    Imports System.Windows.Controls.Primitives
    Imports System.Windows.Controls
    ''' <summary>     Allows the Date Picker Calendar to select month.
    '''                      Use with the attached property IsMonthYear Property.
    ''' </summary>
    ''' <remarks> Source : https://stackoverflow.com/questions/1798513/wpf-toolkit-datepicker-month-year-only 
    '''           Author : </remarks>
    Public Class DatePickerCalendar
 
    Public Shared IsMonthYearProperty As DependencyProperty = DependencyProperty.RegisterAttached("IsMonthYear", GetType(System.Boolean), GetType(DatePickerCalendar), New PropertyMetadata(AddressOf OnIsMonthYearChanged))
    Public Shared Function GetIsMonthYear(ByVal dobj As DependencyObject) As Boolean
        Return CType(dobj.GetValue(IsMonthYearProperty), Boolean)
    End Function
    Public Shared Sub SetIsMonthYear(ByVal dobj As DependencyObject, ByVal value As Boolean)
        dobj.SetValue(IsMonthYearProperty, value)
    End Sub
    Private Shared Sub OnIsMonthYearChanged(ByVal dobj As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
        Dim MyDatePicker = CType(dobj, DatePicker)
        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Loaded, _
                        New Action(Of DatePicker, DependencyPropertyChangedEventArgs)(AddressOf SetCalendarEventHandlers), MyDatePicker, e)
    End Sub
    Private Shared Sub SetCalendarEventHandlers(ByVal datePicker As DatePicker, ByVal e As DependencyPropertyChangedEventArgs)
        If (e.NewValue = e.OldValue) Then
            Return
        End If
        If CType(e.NewValue, Boolean) Then
            AddHandler datePicker.CalendarOpened, AddressOf DatePickerOnCalendarOpened
            AddHandler datePicker.CalendarClosed, AddressOf DatePickerOnCalendarClosed
        Else
            RemoveHandler datePicker.CalendarOpened, AddressOf DatePickerOnCalendarOpened
            RemoveHandler datePicker.CalendarClosed, AddressOf DatePickerOnCalendarClosed
        End If
    End Sub
    Private Shared Sub DatePickerOnCalendarOpened(ByVal sender As Object, ByVal routedEventArgs As RoutedEventArgs)
        Dim MyCalendar = GetDatePickerCalendar(sender)
        MyCalendar.DisplayMode = CalendarMode.Year
        AddHandler MyCalendar.DisplayModeChanged, AddressOf CalendarOnDisplayModeChanged
    End Sub
    Private Shared Sub DatePickerOnCalendarClosed(ByVal sender As Object, ByVal routedEventArgs As RoutedEventArgs)
        Dim MyDatePicker = CType(sender, DatePicker)
        Dim MyCalendar = GetDatePickerCalendar(sender)
        MyDatePicker.SelectedDate = MyCalendar.SelectedDate
        RemoveHandler MyCalendar.DisplayModeChanged, AddressOf CalendarOnDisplayModeChanged
    End Sub
    Private Shared Sub CalendarOnDisplayModeChanged(ByVal sender As Object, ByVal e As CalendarModeChangedEventArgs)
        Dim MyCalendar = CType(sender, Calendar)
        If (MyCalendar.DisplayMode <> CalendarMode.Month) Then
            Return
        End If
        MyCalendar.SelectedDate = GetSelectedCalendarDate(MyCalendar.DisplayDate)
        Dim MyDatePicker = GetCalendarsDatePicker(MyCalendar)
        MyDatePicker.IsDropDownOpen = False
    End Sub
    Private Shared Function GetDatePickerCalendar(ByVal sender As Object) As Calendar
        Dim MyDatePicker = CType(sender, DatePicker)
        Dim MyPopup = CType(MyDatePicker.Template.FindName("PART_Popup", MyDatePicker), Popup)
        Return CType(MyPopup.Child, Calendar)
    End Function
    Private Shared Function GetCalendarsDatePicker(ByVal child As FrameworkElement) As DatePicker
        Dim MyParent = CType(child.Parent, FrameworkElement)
        If (MyParent.Name = "PART_Root") Then
            Return CType(MyParent.TemplatedParent, DatePicker)
        End If
        Return GetCalendarsDatePicker(MyParent)
    End Function
    Private Shared Function GetSelectedCalendarDate(ByVal selectedDate As DateTime?) As DateTime?
        If Not selectedDate.HasValue Then
            Return Nothing
        End If
        Return New DateTime(selectedDate.Value.Year, selectedDate.Value.Month, 1)
    End Function
    End Class
