    open System
    open System.Drawing
    open System.Windows.Forms
    open System.Threading
    let form = new Form()
    form.Size <- new Size(100, 100)
    async {
        do! Async.Sleep 1000
        form.Size <- new Size(200, 200)
    } |> Async.Start
    do Application.Run form
