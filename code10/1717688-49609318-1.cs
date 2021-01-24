        [assembly:ExportRenderer(typeof(MapsDemo.CustomMap),
            typeof(MarkerClusterRenderer))]
        namespace MapsDemo.Droid
        {
            public class MarkerClusterRenderer:MapRenderer,IOnMapReadyCallback
            {
                public MarkerClusterRenderer(Context c) : base(c)
                {
                }
                protected override void OnMapReady(GoogleMap map)
                {
                    base.OnMapReady(map);
                    var markerOptions = new Android.Gms.Maps.Model.MarkerOptions();
                    markerOptions.SetTitle("Winffeeeeeeeeeee");
                    markerOptions.SetPosition(new Android.Gms.Maps.Model.LatLng(37.051060, -122.014684));
                    markerOptions.Draggable(true);
                    map.AddMarker(markerOptions);
            
                    map.MarkerDrag += Map_MarkerDrag;
                }
                private void Map_MarkerDrag(object sender, GoogleMap.MarkerDragEventArgs e)
                {
                    //implement your marker drag event here
                }
                protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
                {
                    base.OnElementChanged(e);
                    Control.GetMapAsync(this);
                }
        
            }
        }
