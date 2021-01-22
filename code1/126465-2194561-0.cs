    type MyRect = { X : int; Y : int; Width : int; Height : int }
    let r = { X = 0; Y = 0; Width = 200; Height = 100 }
    // You'll often need to create clone with one field changed:
    let rMoved1 = { X = 123; Y = r.Y; Width = r.Width; Height = r.Height }
    // The same thing can be written using 'with' keyword:
    let rMoved2 = { r with  X = 123 }
