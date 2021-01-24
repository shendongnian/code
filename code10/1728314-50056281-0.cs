    Private mElement As MediaElement
    Private Synth As SpeechSynthesizer
    Private currentStream As SpeechSynthesisStream 
    Private Async Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        mElement = New MediaElement
        rootgrid.Children.Add(mElement)
    End Sub
    Async Function SayAsync(ByVal text As String) As Task
        Synth = New SpeechSynthesizer
        currentStream = Await Synth.SynthesizeTextToStreamAsync(text)
        mElement.Volume = 10 / 100
        mElement.PlaybackRate = 50 / 100
        mElement.SetSource(currentStream, String.Empty)
    End Function
    Private Async Sub btnstart_Click(sender As Object, e As RoutedEventArgs)
        Await SayAsync("The privacy statement was declined." +
           "Go to Settings -> Privacy -> Speech, inking and typing, and ensure you" +
           "have viewed the privacy policy, and 'Get To Know You' is enabled.")
    End Sub
    Private Sub btnchangevolume_Click(sender As Object, e As RoutedEventArgs)
        mElement.Volume = 50 / 100
    End Sub
