    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Google.Protobuf.WellKnownTypes;
    using Grpc.Core;
    using FlowerShop.Grpc.Service.Joint;
    using FlowerShop.Grpc.Service.Joint.Event;
    using FlowerShop.Grpc.Service.System;
    using UnityEngine;
    
    namespace Scripts
    {
        public class GrpcSetup : MonoBehaviour
        {
            private int _loopController = 1;
            private Channel _grpcChannel;
    
            private EventService.EventServiceClient _eventService;
            private RegisterOnEvent _request;
            private IAsyncStreamReader<Any> _responseStream;
            private Any _receivedEvent;
            private JointPositionChangedEvent _positionChangedEvent;
    
            // this method will be called only one time in start method in another class
            // .. I am initializing a channel for Grpc and some required properties for my ObserveEvents method
            public void GrpcChannelInitialization()
            {
                _grpcChannel = new Channel("192.168.100.16", 50001, ChannelCredentials.Insecure);
                
                _eventService = new EventService.EventServiceClient(_grpcChannel);
                _request = new RegisterOnEvent();
            }
    
            // this method will be called in Update in another class
            public async void GrpcUpdateMethod()
            {
                try
                {
                    // to get the initial axesVales only one time
                    if (_loopController == 1)
                    {
                        await GetJointPositionOnDemand(_grpcChannel, "Flower_li35443");
                        _loopController = 0;
                    }
    
                    // receiving Events only when they are available
                    await ObserveEvents();
                }
                catch (RpcException e)
                {
                    Debug.LogError("Connection Error: " + e);
                }
            }
    
            // this method will be called every frame, the good thing about it is that, I will only receive events, 
            // .. when there are some available.
            private async Task ObserveEvents()
            {
                using (var call = _eventService.OnEvent(_request))
                {
                    _responseStream = call.ResponseStream;
    
                    if (await _responseStream.MoveNext())
                    {
                        Debug.Log("New Event is available.");
    
                        _receivedEvent = call.ResponseStream.Current;
    
                        if (_receivedEvent.TypeUrl.EndsWith(JointPositionChangedEvent.Descriptor.FullName))
                        {
                            _positionChangedEvent = _receivedEvent.Unpack<JointPositionChangedEvent>();
    
                            _positionChangedEvent.Positions.ToList().ForEach(i =>
                                Instance.Ref.AxesValues[i.Index - 1] = (float) Math.Round(i.Value * Mathf.Rad2Deg, 2));
                        }
                    }
                }
            }
    
            // if I want to get Joint values whenever I like, regardless of ObserveEvents method architecture
            // .. at this moment, I am calling it, one time in Update method
            private async Task GetJointPositionOnDemand(Channel channel, string flowerName)
            {
                var client = new JointPositionService.JointPositionServiceClient(channel);
                var requestLocal = new GetJointPositionRequest {FlowerName= flowerName};
                var response = await client.GetJointPositionAsync(requestLocal);
    
                foreach (var i in response.Positions)
                {
                    var value = i.Value * Mathf.Rad2Deg;
                    Instance.Ref.AxesValues[i.Index - 1] = (float) Math.Round(value, 2);
                }
            }
    
            // this will be called in Unity reserved method: OnApplicationQuit
            // .. so we are trying to get rid of our opened channel
            public async Task ChannelShutDown()
            {
                await _grpcChannel.ShutdownAsync();
            }
        }
    }
